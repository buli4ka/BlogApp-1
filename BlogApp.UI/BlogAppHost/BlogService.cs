using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BlogAppHost
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "BlogService" в коде и файле конфигурации.
    public class BlogService : IBlogService
    {
        public void DoWork()
        {
        }

        public UploadFileInfo UploadFile(UploadFileRequest info)
        {
            //filedto file = new filedto() { filepath = info.filepath };
            //fileservice.updeteorcreate(file);
            //fileservice.savechanges();
            //file = fileservice.getall().firstordefault((f) => f.filepath == info.filepath);
            //file.filepath = $"files\\{file.fileid}.{file.filepath}";
            //fileservice.updeteorcreate(file);
            //fileservice.savechanges();
            //using (var filestream = file.create(file.filepath))
            //{
            //    info.filebytestream.seek(0, seekorigin.begin);
            //    info.filebytestream.copyto(filestream);
            //}
            //  return new UploadFileInfo() { file = file };
            return null;
        }

        public DownloadFileInfo DownloadFile(DownloadFileRequest request)
        {

            //FileDTO file = fileService.GetAll().FirstOrDefault((f) => f.FileId == request.fileId);
            DownloadFileInfo downloadFileInfo = new DownloadFileInfo();
            //downloadFileInfo.fileName = Path.GetFileName(file.FilePath);
            //downloadFileInfo.FileByteStream = new MemoryStream();
            //using (var fileStream = File.OpenRead(file.FilePath))
            //{
            //    fileStream.Seek(0, SeekOrigin.Begin);
            //    fileStream.CopyTo(downloadFileInfo.FileByteStream);
            //}
            downloadFileInfo.fileName = "resume.docx";
            downloadFileInfo.FileByteStream = new MemoryStream();
            using (var fileStream = File.OpenRead(@"C:\123\resume.docx"))
            {
                
                fileStream.Seek(0, SeekOrigin.Begin);
                fileStream.CopyTo(downloadFileInfo.FileByteStream);
                fileStream.Flush();
                Console.WriteLine("Server copied to file");
                Console.WriteLine(downloadFileInfo.FileByteStream.Length);
            }

            return downloadFileInfo;
        }
        public Stream  DownloadFileTest()
        {

         
            var fileStream = File.OpenRead(@"C:\123\resume.docx");
            

                
                Console.WriteLine("Server open file");
                Console.WriteLine(fileStream.Length);
            

            return fileStream;
        }
    }
}
