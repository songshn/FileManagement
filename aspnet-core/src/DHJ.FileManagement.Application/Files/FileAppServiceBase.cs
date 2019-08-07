using DHJ.FileManagement.FileStore;

namespace DHJ.FileManagement.Files
{
    public class FileAppServiceBase : FileManagementAppServiceBase
    {
        public FileStoreManager FileStoreManager { get; set; }
    }
}