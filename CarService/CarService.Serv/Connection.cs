using System;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using CarService.Common.Serv;
using CarService.Serv.Handler;
using CarService.Serv.Services;

namespace CarService.Serv
{
    public class Connection
    {
        private TcpClient _tcpClient;
        private IMethodService _methodService;

        public Connection(TcpClient tcpClient, IMethodService methodService)
        {
            _tcpClient = tcpClient;
            _methodService = methodService;
        }

        public void Process()
        {
            NetworkStream stream = null;

            try
            {
                //Получение сетевого потока
                stream = _tcpClient.GetStream();

                byte[] buffer = new byte[_tcpClient.ReceiveBufferSize];

                StringBuilder response = new StringBuilder();
                int bytes = default;

                do
                {
                    bytes = stream.Read(buffer, 0, buffer.Length);
                    response.Append(Encoding.Unicode.GetString(buffer, 0, bytes));
                }
                while (stream.DataAvailable);

                string json = response.ToString();

                var query = JsonSerializer.Deserialize<ServerQuery>(json)!;

                json = QueryHandler.SearchType(query, _methodService);

                buffer = Encoding.Unicode.GetBytes(json);
                stream.Write(buffer, 0, buffer.Length);

            }

            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }

            finally
            {
                if (stream != null)
                    stream.Close();

                if (_tcpClient != null)
                    _tcpClient.Close();
            }
        }
    }
}

