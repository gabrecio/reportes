namespace ERP.Reports.Api.Models.Responses.Core
{
    public class FileModelResponse : ResponseBase
    {

        public FileModel File { get; }



        private FileModelResponse(FileModel file)
            : base(200, "Success")
        {
            File = file;
        }
        public static FileModelResponse Create(FileModel file)
            => new FileModelResponse(file);
    }
}