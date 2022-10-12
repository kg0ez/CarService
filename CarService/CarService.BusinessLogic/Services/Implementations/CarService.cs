using System;
using AutoMapper;
using CarService.Common.ModelDto;
using CarService.Model;
using CarService.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace CarService.BusinessLogic.Services
{
    public class CarService: ICarService
    {
        private readonly CarServiceContext _context;
        private readonly IMapper _mapper;

        public CarService(CarServiceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<CarDto> Get()
        {
            var cars = _context.Cars
                .Include(c => c.CarStore)
                .AsNoTracking()
                .ToList();

            var carsDto = _mapper.Map<List<CarDto>>(cars);

            return carsDto;
        }

        public CarDto Get(int id)
        {
            var car = _context.Cars
                .Include(c => c.Characteristics)
                .Include(c=>c.AdditionalCharacteristic)
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == id);

            var carDto = _mapper.Map<CarDto>(car);
            return carDto;
        }

        public void Sync()
        {
            var cars =new List<Car> {
                new Car
            {
                Brand="BMW",
                Model="e39",
                Img = "01.jpeg bmw392.jpeg bmw393.jpeg",
                Cost = 22058,
                Characteristics = new Characteristic
                {
                    Transmission = "механика",
                    Carcase = "седан",
                    EngineType ="дизель",
                    DriveUnit = "передний привод",
                    Year = "2003",
                    Description = "бмв е39, только из Германии( покупалась у дилера Мюнхен) , в самом топовом цвете карбоншварц, выпуск 04.19 первая регистрация 05.19 , пробег оригинальный и подтвержден дилером бмв, растаможен на РФ, в заказной(максимальной) комплектации и состоянии нового авто! ",
                    Mileage = 150000
                },
                CarStore = new CarStore
                {
                    Amount = 2
                },
                AdditionalCharacteristic = new AdditionalCharacteristic
                {
                    SystemSecurity = "ABS, ESP, сигнализация, иммобилайзер, антипробуксовочная",
                    Pillow = "передние, боковые, задние",
                    SystemAssist= "датчик дождя, парктроники, контроль мертвых зон на зеркалах",
                    Comfort= "круиз-контроль, управление мультимедиа с руля, электрорегулировка сидений, передние электро-стеклоподъёмники, задние электро-стеклоподъёмники",
                    Heating="руля, зеркал, сидений",
                    Climate="климат-контроль, кондиционер",
                    Multimedia="AUX или iPod, Bluetooth, CD или MP3, USB, мультимедийный экран, штатная навигация",
                    Lights="Ксеноновые, противотуманные, светодиодные",
                }

            },new Car
            {
                Brand="BMW",
                Model="3 серия G20",
                Img = "bmw31.jpeg bmw32.jpeg bmw33.jpeg",
                Cost = 155046,
                Characteristics = new Characteristic
                {
                    Transmission = "автомат",
                    Carcase = "седан",
                    EngineType ="дизель",
                    DriveUnit = "задний привод",
                    Year = "2019",
                    Description="Едва выехав на дорогу, новый седан BMW 3 серии оставляет позади предрассудки и опережает даже самые смелые ожидания. В очередной раз легендарная модель предстает в новом подобии. Обновленный дизайн – как символ наступления новой эры. Совершенный спортивный седан приводится в движение еще более мощными и экономичными двигателями.",
                    Mileage = 75000
                },
                CarStore = new CarStore
                {
                    Amount = 4
                },
                AdditionalCharacteristic = new AdditionalCharacteristic
                {
                    SystemSecurity = "ABS, ESP, сигнализация, иммобилайзер, антипробуксовочная",
                    Pillow = "передние, боковые, задние",
                    SystemAssist= "датчик дождя, парктроники, контроль мертвых зон на зеркалах",
                    Comfort= "круиз-контроль, управление мультимедиа с руля, электрорегулировка сидений, передние электро-стеклоподъёмники, задние электро-стеклоподъёмники",
                    Heating="руля, зеркал, сидений",
                    Climate="климат-контроль, кондиционер",
                    Multimedia="AUX или iPod, Bluetooth, CD или MP3, USB, мультимедийный экран, штатная навигация",
                    Lights="Ксеноновые, противотуманные, светодиодные",
                }

            },
                new Car
            {
                Brand="Audi",
                Model="A7 Type 4K8",
                Img = "audiA71.jpeg audiA72.jpeg audiA73.jpeg",
                Cost = 169259,
                Characteristics = new Characteristic
                {
                    Transmission = "автомат",
                    Carcase = "лифтбек",
                    EngineType ="дизель",
                    DriveUnit = "постоянный полный привод",
                    Year = "2019",
                    Description="Спорт пакет ! Оригинальный пробег 75.000 км. Чистая история , один хозяин!Полный комплект ключей , сервисное обслуживание на Ауди центр !Состояние нового автомобиля , безаварийное прошлое, вся в родном окрасе ,богатая комплектация , полный S-line, диски R-20!",
                    Mileage = 75000
                },
                CarStore = new CarStore
                {
                    Amount = 8
                },
                AdditionalCharacteristic = new AdditionalCharacteristic
                {
                    SystemSecurity = "ABS, ESP, сигнализация, иммобилайзер, антипробуксовочная",
                    Pillow = "передние, боковые, задние",
                    SystemAssist= "датчик дождя, парктроники, контроль мертвых зон на зеркалах",
                    Comfort= "круиз-контроль, управление мультимедиа с руля, электрорегулировка сидений, передние электро-стеклоподъёмники, задние электро-стеклоподъёмники",
                    Heating="руля, зеркал, сидений",
                    Climate="климат-контроль, кондиционер",
                    Multimedia="AUX или iPod, Bluetooth, CD или MP3, USB, мультимедийный экран, штатная навигация",
                    Lights="Ксеноновые, противотуманные, светодиодные",
                }

            },
                new Car
            {
                Brand="Audi",
                Model="A4 B9",
                Img = "audiA41.jpeg audiA42.jpeg audiA43.jpeg",
                Cost = 120259,
                Characteristics = new Characteristic
                {
                    Transmission = "автомат",
                    Carcase = "седан",
                    EngineType ="бензин",
                    DriveUnit = "постоянный полный привод",
                    Year = "2019",
                    Description ="Срочно хороший торг. Состояние нового авто , любые проверки за ваши деньги без пробега в р.б. оригинальный пробег .AUDI A4 B9 2.0 QUATTRO PREMIUMО. S-LINE . 252 л.с ,чёрный потолок ,люк. Легкосплавные диски R17. Подсветка салона, камера заднего вида . 3-зонный климат контроль .Если телефон недоступен можно Вайбер . Все вопросы по телефону .",
                    Mileage = 25000
                },
                CarStore = new CarStore
                {
                    Amount = 3
                },
                AdditionalCharacteristic = new AdditionalCharacteristic
                {
                    SystemSecurity = "ABS, ESP, сигнализация, иммобилайзер, антипробуксовочная",
                    Pillow = "передние, боковые, задние",
                    SystemAssist= "датчик дождя, парктроники, контроль мертвых зон на зеркалах",
                    Comfort= "круиз-контроль, управление мультимедиа с руля, электрорегулировка сидений, передние электро-стеклоподъёмники, задние электро-стеклоподъёмники",
                    Heating="руля, зеркал, сидений",
                    Climate="климат-контроль, кондиционер",
                    Multimedia="AUX или iPod, Bluetooth, CD или MP3, USB, мультимедийный экран, штатная навигация",
                    Lights="Ксеноновые, противотуманные, светодиодные",
                }

            },
                new Car
            {
                Brand="Audi",
                Model="Q7 4M",
                Img = "audiQ71.jpeg audiQ72.jpeg audiQ73.jpeg",
                Cost = 144710,
                Characteristics = new Characteristic
                {
                    Transmission = "автомат",
                    Carcase = "внедорожник",
                    EngineType ="бензин",
                    DriveUnit = "постоянный полный привод",
                    Year = "2018",
                    Description="Практически новый авто. Дата выпуска декабрь 2018 года. Богатая комплектация: рыжая кожа, вентиляция сидений, обогрев задних и передних сидений, 4-х зонный климат, датчики мертвых зон, премиальная аудиосистема Bose, голосовое управление, навигация, понарамная крыша, цифровая панель, беспроводная зарядка телефона и многое другое.",
                    Mileage = 37000
                },
                CarStore = new CarStore
                {
                    Amount = 6
                },
                AdditionalCharacteristic = new AdditionalCharacteristic
                {
                    SystemSecurity = "ABS, ESP, сигнализация, иммобилайзер, антипробуксовочная",
                    Pillow = "передние, боковые, задние",
                    SystemAssist= "датчик дождя, парктроники, контроль мертвых зон на зеркалах",
                    Comfort= "круиз-контроль, управление мультимедиа с руля, электрорегулировка сидений, передние электро-стеклоподъёмники, задние электро-стеклоподъёмники",
                    Heating="руля, зеркал, сидений",
                    Climate="климат-контроль, кондиционер",
                    Multimedia="AUX или iPod, Bluetooth, CD или MP3, USB, мультимедийный экран, штатная навигация",
                    Lights="Ксеноновые, противотуманные, светодиодные",
                }

            },
                new Car
            {
                Brand="Bentley",
                Model="Bentayga I",
                Img = "ben1.jpeg ben2.jpeg ben3.jpeg",
                Cost = 480384,
                Characteristics = new Characteristic
                {
                    Transmission = "автомат",
                    Carcase = "внедорожник",
                    EngineType ="дизель",
                    DriveUnit = "постоянный полный привод",
                    Year = "2017",
                    Description="Этот внедорожник производит неизгладимое впечатление своим внушительным и при этом динамичным обликом. Главный элемент дизайна передней части автомобиля — широкая сетчатая решетка радиатора, в которую плавно переходит удлиненный капот. Ярко выраженная рельефность переднего бампера подчеркивает внушительный динамический потенциал нового Bentayga, а овальные фары головного света с эффектом граненого хрусталя привносят в облик автомобиля элемент изысканности и роскоши.",
                    Mileage = 54000
                },
                CarStore = new CarStore
                {
                    Amount = 2
                },
                AdditionalCharacteristic = new AdditionalCharacteristic
                {
                    SystemSecurity = "ABS, ESP, сигнализация, иммобилайзер, антипробуксовочная",
                    Pillow = "передние, боковые, задние",
                    SystemAssist= "датчик дождя, парктроники, контроль мертвых зон на зеркалах",
                    Comfort= "круиз-контроль, управление мультимедиа с руля, электрорегулировка сидений, передние электро-стеклоподъёмники, задние электро-стеклоподъёмники",
                    Heating="руля, зеркал, сидений",
                    Climate="климат-контроль, кондиционер",
                    Multimedia="AUX или iPod, Bluetooth, CD или MP3, USB, мультимедийный экран, штатная навигация",
                    Lights="Ксеноновые, противотуманные, светодиодные",
                }

            },
                new Car
            {
                Brand="Lexus",
                Model="RX IV",
                Img = "lex1.jpeg lex2.jpeg lex3.jpeg",
                Cost = 180629,
                Characteristics = new Characteristic
                {
                    Transmission = "автомат",
                    Carcase = "внедорожник",
                    EngineType ="бензин",
                    DriveUnit = "постоянный полный привод",
                    Year = "2019",
                    Description="Этот внедорожник производит неизгладимое впечатление своим внушительным и при этом динамичным обликом. Главный элемент дизайна передней части автомобиля — широкая сетчатая решетка радиатора, в которую плавно переходит удлиненный капот. Ярко выраженная рельефность переднего бампера подчеркивает внушительный динамический потенциал нового Bentayga, а овальные фары головного света с эффектом граненого хрусталя привносят в облик автомобиля элемент изысканности и роскоши.",
                    Mileage = 42000
                },
                CarStore = new CarStore
                {
                    Amount = 4
                },
                AdditionalCharacteristic = new AdditionalCharacteristic
                {
                    SystemSecurity = "ABS, ESP, сигнализация, иммобилайзер, антипробуксовочная",
                    Pillow = "передние, боковые, задние",
                    SystemAssist= "датчик дождя, парктроники, контроль мертвых зон на зеркалах",
                    Comfort= "круиз-контроль, управление мультимедиа с руля, электрорегулировка сидений, передние электро-стеклоподъёмники, задние электро-стеклоподъёмники",
                    Heating="руля, зеркал, сидений",
                    Climate="климат-контроль, кондиционер",
                    Multimedia="AUX или iPod, Bluetooth, CD или MP3, USB, мультимедийный экран, штатная навигация",
                    Lights="Ксеноновые, противотуманные, светодиодные",
                }

            },
                new Car
            {
                Brand="Volvo",
                Model="XC60 II",
                Img = "volovoXC601.jpeg volovoXC602.jpeg volovoXC603.jpeg",
                Cost = 180629,
                Characteristics = new Characteristic
                {
                    Transmission = "автомат",
                    Carcase = "внедорожник",
                    EngineType ="дизель",
                    DriveUnit = "передний привод",
                    Year = "2019",
                    Description="Диодные фары. Распознавание знаков и камер. Двухзоный климат. Функция Старт/стоп. Очень экономичная. Расход город 6.5 литров. Парктроники перед и зад. Электро-багажник. Электро-фаркоп. Новая резина Michelin.",
                    Mileage = 80000
                },
                CarStore = new CarStore
                {
                    Amount = 4
                },
                AdditionalCharacteristic = new AdditionalCharacteristic
                {
                    SystemSecurity = "ABS, ESP, сигнализация, иммобилайзер, антипробуксовочная",
                    Pillow = "передние, боковые, задние",
                    SystemAssist= "датчик дождя, парктроники, контроль мертвых зон на зеркалах",
                    Comfort= "круиз-контроль, управление мультимедиа с руля, электрорегулировка сидений, передние электро-стеклоподъёмники, задние электро-стеклоподъёмники",
                    Heating="руля, зеркал, сидений",
                    Climate="климат-контроль, кондиционер",
                    Multimedia="AUX или iPod, Bluetooth, CD или MP3, USB, мультимедийный экран, штатная навигация",
                    Lights="Ксеноновые, противотуманные, светодиодные",
                }

            },
                new Car
            {
                Brand="Volvo",
                Model="V60 II",
                Img = "volovoV601.jpeg volovoV602.jpeg volovoV603.jpeg",
                Cost = 62794,
                Characteristics = new Characteristic
                {
                    Transmission = "автомат",
                    Carcase = "универсал",
                    EngineType ="дизель",
                    DriveUnit = "передний привод",
                    Year = "2019",
                    Description="Диодные фары. Распознавание знаков и камер. Двухзоный климат. Функция Старт/стоп. Очень экономичная. Расход город 6.5 литров. Парктроники перед и зад. Электро-багажник. Электро-фаркоп. Новая резина Michelin.",
                    Mileage = 263000
                },
                CarStore = new CarStore
                {
                    Amount = 4
                },
                AdditionalCharacteristic = new AdditionalCharacteristic
                {
                    SystemSecurity = "ABS, ESP, сигнализация, иммобилайзер, антипробуксовочная",
                    Pillow = "передние, боковые, задние",
                    SystemAssist= "датчик дождя, парктроники, контроль мертвых зон на зеркалах",
                    Comfort= "круиз-контроль, управление мультимедиа с руля, электрорегулировка сидений, передние электро-стеклоподъёмники, задние электро-стеклоподъёмники",
                    Heating="руля, зеркал, сидений",
                    Climate="климат-контроль, кондиционер",
                    Multimedia="AUX или iPod, Bluetooth, CD или MP3, USB, мультимедийный экран, штатная навигация",
                    Lights="Ксеноновые, противотуманные, светодиодные",
                }

            },
            };
            _context.Cars.AddRange(cars);
            _context.SaveChanges();
        }
    }
}

