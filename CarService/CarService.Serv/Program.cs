using System.Net;
using System.Net.Sockets;
using AutoMapper;
using CarService.BusinessLogic.Mapper;
using CarService.BusinessLogic.Services;
using CarService.Model;
using CarService.Serv;
using CarService.Serv.Services;
using Microsoft.Extensions.DependencyInjection;

var mapperConfiguration = new MapperConfiguration(x =>
{
    x.AddProfile<MappingProfile>();
});

mapperConfiguration.AssertConfigurationIsValid();
IMapper mapper = mapperConfiguration.CreateMapper();

var serviceProvider = new ServiceCollection()
            .AddLogging()
            .AddSingleton<IMethodService, MethodService>()
            .AddSingleton<IBasketService, BasketService>()
            .AddSingleton<IBasketJsonService, BasketJsonService>()
            .AddSingleton<IDetailService, DetailService>()
            .AddSingleton<IDetailJsonService, DetailJsonService>()
            .AddSingleton<ICarJsonService, CarJsonService>()
            .AddSingleton<IStoreJsonService, StoreJsonService>()
            .AddSingleton<IStoreService, StoreService>()
            .AddSingleton<CarServiceContext, CarServiceContext>()
            .AddSingleton<ICarService, CarService.BusinessLogic.Services.CarService>()
            .AddSingleton(mapper)
            .BuildServiceProvider();

var carService = serviceProvider.GetService<ICarService>();
var detailService = serviceProvider.GetService<IDetailService>();
var methodService = serviceProvider.GetService<IMethodService>();

//detailService.Sync();
//carService.Sync();
//Console.WriteLine("sex");
//Console.ReadLine();

TcpListener listener = null;

string IP = "127.0.0.1";
int PORT = 8080;

try
{
    listener = new TcpListener(IPAddress.Parse(IP), PORT);
    listener.Start();

    while (true)
    {
        //Для входящих
        TcpClient client = listener.AcceptTcpClient();

        Connection connection = new Connection(
            client, methodService);

        Thread clientThread = new Thread(new ThreadStart(connection.Process));
        clientThread.Start();
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    if (listener != null)
        listener.Stop();
}

