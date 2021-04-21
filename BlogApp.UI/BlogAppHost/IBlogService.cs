using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BlogAppHost
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IBlogService" в коде и файле конфигурации.
    [ServiceContract]
    public interface IBlogService
    {
        [OperationContract]
        void DoWork();
        [OperationContract]
        UploadFileInfo UploadFile(UploadFileRequest info);
        [OperationContract]
        DownloadFileInfo DownloadFile(DownloadFileRequest info);
        [OperationContract]
        Stream DownloadFileTest();
    }
    [MessageContract]
    public class UploadFileInfo
    {
     //   [MessageBodyMember]
        //public FileDTO file;
    }
    [MessageContract]
    public class DownloadFileInfo : IDisposable
    {
        [MessageHeader(MustUnderstand = true)]
        public int fileId;
        [MessageHeader(MustUnderstand = true)]
        public string fileName;
        [MessageBodyMember]
        public System.IO.Stream FileByteStream;

        public void Dispose()
        {
            if (FileByteStream != null)
            {
                FileByteStream.Close();
                FileByteStream = null;
            }
        }
    }
    [MessageContract]
    public class DownloadFileRequest
    {
        [MessageBodyMember]
        public int fileId;

    }
    [MessageContract]
    public class UploadFileRequest : IDisposable
    {
        [MessageHeader(MustUnderstand = true)]
        public string filePath;
        [MessageBodyMember]
        public System.IO.Stream FileByteStream;

        public void Dispose()
        {
            if (FileByteStream != null)
            {
                FileByteStream.Close();
                FileByteStream = null;
            }
        }
    }
}
