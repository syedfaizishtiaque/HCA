namespace HCA.Services
{
    public class servErrorLog
    {
        public async static Task WriteErrorLog(string messageType, Exception exception, string function)
        {
            try
            {
                string SubFileName = DateTime.Now.ToString("dd-MM-yyyy");
                string LogPath = Path.Combine(Directory.GetCurrentDirectory(), "Error_LOG");
                if (!Directory.Exists(LogPath))
                {
                    Directory.CreateDirectory(LogPath);
                }
                LogPath = LogPath + "/Log_" + SubFileName + ".txt";
                if (!System.IO.File.Exists(LogPath))
                {
                    var myFile = File.Create(LogPath);
                    myFile.Close();
                    using (StreamWriter writer = new StreamWriter(LogPath, append: true))
                    {
                        await writer.WriteLineAsync("   Date   |  Time  | Log Type | Function | Message");
                        writer.Close();
                    }
                }
                using (StreamWriter writer = new StreamWriter(LogPath, append: true))
                {
                    string date = DateTime.Now.ToString("dd-MMM-yyyy");
                    string time = DateTime.Now.ToString("hh:mm ss");
                    await writer.WriteLineAsync(date + " | " + time + " | " + messageType + " | " + function + " | " + exception.ToString());
                    await writer.WriteLineAsync(Environment.NewLine);
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async static Task WriteRecordLog(string messageType, string message, string function)
        {
            try
            {
                string SubFileName = DateTime.Now.ToString("dd-MM-yyyy");
                string LogPath = Path.Combine(Directory.GetCurrentDirectory(), "Error_LOG");
                if (!Directory.Exists(LogPath))
                {
                    Directory.CreateDirectory(LogPath);
                }
                LogPath = LogPath + "/Log_" + SubFileName + ".txt";
                if (!System.IO.File.Exists(LogPath))
                {
                    var myFile = File.Create(LogPath);
                    myFile.Close();
                    using (StreamWriter writer = new StreamWriter(LogPath, append: true))
                    {
                        await writer.WriteLineAsync("   Date   |  Time  | Log Type | Function | Message");
                        writer.Close();
                    }
                }
                using (StreamWriter writer = new StreamWriter(LogPath, append: true))
                {
                    string date = DateTime.Now.ToString("dd-MMM-yyyy");
                    string time = DateTime.Now.ToString("hh:mm ss");
                    await writer.WriteLineAsync(date + " | " + time + " | " + messageType + " | " + function + " | " + message);
                    await writer.WriteLineAsync(Environment.NewLine);
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
