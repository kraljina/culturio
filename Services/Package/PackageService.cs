using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Span.Culturio.Api.Data;
using Span.Culturio.Api.Data.Entities;
using Span.Culturio.Api.Models.Package;

namespace Span.Culturio.Api.Services.Package {
    public class PackageService : IPackageService {

        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public PackageService(IMapper mapper, DataContext context) {
            _mapper = mapper;
            _context = context;
        }

        public async Task<PackageDto> CreatePackageAsync(CreatePackageDto createPackageDto) {
            var createPackageItemsDto = createPackageDto.PackageItems;

            var package = _mapper.Map<Data.Entities.Package>(createPackageDto);
            var packageItems = _mapper.Map<List<PackageItem>>(createPackageItemsDto);

            await _context.AddAsync(package);
            await _context.SaveChangesAsync();

            packageItems.ForEach(x => x.PackageId = package.Id);

            await _context.AddRangeAsync(packageItems);
            await _context.SaveChangesAsync();

            var packageItemsDto = _mapper.Map<IEnumerable<PackageItemDto>>(packageItems);

            var packageDto = _mapper.Map<PackageDto>(package);
            packageDto.CultureObjects = packageItemsDto;

            return packageDto;
        }
        
        public async Task<List<PackageDto>> GetPackagesAsync() {
            var packages = _context.Packages.ToListAsync();
            var packageItems = _context.PackageItems.ToListAsync();

            var packageDtos = _mapper.Map<List<PackageDto>>(packages);
            var packageItemDtos = _mapper.Map<List<PackageItemDto>>(packageItems);

            packageDtos.ForEach(x =>
            {
                x.CultureObjects = packageItemDtos.Where(y => y.Id == x.Id).ToList();
            });

            return packageDtos;
        }
    }
}
