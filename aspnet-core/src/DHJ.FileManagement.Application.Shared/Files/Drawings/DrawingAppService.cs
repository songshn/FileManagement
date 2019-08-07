using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using DHJ.FileManagement.Files.Drawings.Dto;

namespace DHJ.FileManagement.Files.Drawings
{
    public interface DrawingAppService : IApplicationService
    {
        Task CreateOrUpdateDrawing(CreateOrUpdateDrawingInput input);

        Task<GetDrawingForEditOutput> GetDrawingForEdit(NullableIdDto input);

        Task DeleteDrawing(EntityDto input);

        Task<ListResultDto<DrawingListDto>> GetDrawings();

        Task<ListResultDto<DrawingListDto>> GetDrawings(int sectionId);
    }
}