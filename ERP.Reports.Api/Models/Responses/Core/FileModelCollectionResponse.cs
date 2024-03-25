using System.Collections.Generic;

namespace ERP.Reports.Api.Models.Responses.Core
{
    public class FileModelCollectionResponse : ResponseBase
    {
        public IEnumerable<FileModel> Files { get; }
        public FileModelCollectionResponse(IEnumerable<FileModel> files)
             : base(200, "Success")
        {
            Files = files;
        }
        public static FileModelCollectionResponse Create(IEnumerable<FileModel> files)
            => new FileModelCollectionResponse(files);
    }
}