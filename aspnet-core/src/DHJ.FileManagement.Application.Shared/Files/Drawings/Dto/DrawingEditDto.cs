using System;
using Abp.Application.Services.Dto;

namespace DHJ.FileManagement.Files.Drawings.Dto
{
    public class DrawingEditDto : NullableIdDto
    {
        public string FileName { get; set; }

        public string FileNumber { get; set; }

        public DateTime ReceiveDate { get; set; }

        public int TotalPages { get; set; }

        public string Remark { get; set; }

        public string DrawingNumber { get; set; }

        public int SectionInfoId { get; set; }
    }
}