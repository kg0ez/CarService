using System;
using AutoMapper;
using CarService.Common.ModelDto;
using CarService.Model;
using CarService.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace CarService.BusinessLogic.Services
{
    public class DetailService:IDetailService
    {
        private readonly CarServiceContext _context;
        private readonly IMapper _mapper;

        public DetailService(CarServiceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<DetailDto> Get()
        {
            var details = _context.Details
                .Include(d => d.Cost)
                .Include(d=>d.DetailStore)
                .AsNoTracking()
                .ToList();

            var detailsDto = _mapper.Map<List<DetailDto>>(details);

            return detailsDto;
        }

        public DetailDto Get(int id)
        {
            var detail = _context.Details
                .Include(d=>d.Cost)
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == id);

            var detailDto = _mapper.Map<DetailDto>(detail);
            return detailDto;
        }

        public void Sync()
        {
            var details = new List<Detail> {
                new Detail
            {
                Name = "Ступица",
                Img = "ступица.png",
                Year = "2022",
                Description = "Ступица колеса — деталь, предназначена для установки колеса автомобиля на ось, именуемой цапфой. Подшипники ступицы, в таком соединении, являются ключевым элементом не только ступицы, но и всей ходовой части в целом, так как именно они отвечают за управляемость автомобилем и во многом обеспечивают безопасность водителя.",
                Weight = 960,
                Cost = new Cost
                {
                    Price = (decimal)14.60,
                    CostDelivery = 2,
                    TimeDelivery = "2 дня"
                },
                DetailStore = new DetailStore { Amount = 9 }
            },
                new Detail
            {
                Name = "Колодки",
                Img = "колодки.png",
                Year = "2022",
                Description = "накладки, которые во время торможения с силой прижимаются к диску — за счет трения колодок о диск машина тормозит. ",
                Weight = 840,
                Cost = new Cost
                {
                    Price = (decimal)50.30,
                    CostDelivery = 2,
                    TimeDelivery = "2 дня"
                },
                DetailStore = new DetailStore { Amount = 40 }
            },
                new Detail
            {
                Name = "Тормозной диск",
                Img = "диск.png",
                Year = "2022",
                Description = "Сейчас на улицах стали все чаще появляться тюнингованные автомобили. Следует отметить, что в последнее время тюнинг пошел намного дальше обычного внешнего обвеса кузова. Начали тюнинговаться элементы топливной системы, двигатель, тормозная система и т.д.",
                Weight = 1690,
                Cost = new Cost
                {
                    Price = (decimal)150,
                    CostDelivery = 4,
                    TimeDelivery = "6 дня"
                },
                DetailStore = new DetailStore { Amount = 8 }
            },new Detail
            {
                Name = "Ароматизатор",
                Img = "ароматизатор.png",
                Year = "2022",
                Description = " изделие из картона или дерева, пропитанное ароматическими отдушками. Также выпускаются в виде жестяных банок, флаконов различной конфигурации из стекла, резины, пластика, ткани и других материалов с ароматическим наполнителем. Их используют для ароматизации помещений или салона автомобиля.",
                Weight = 200,
                Cost = new Cost
                {
                    Price = (decimal)6.02,
                    CostDelivery = 2,
                    TimeDelivery = "3 дня"
                },
                DetailStore = new DetailStore { Amount = 8}
            },new Detail
            {
                Name = "Коврик",
                Img = "коврик.png",
                Year = "2022",
                Description = "Полимерные коврики EVA (ЭВА) это прекрасная возможность обеспечить чистоту в салоне автомобиля не нарушая общего стиля внутренней отделки. Индивидуальное изготовление под размер салона органично вписывает каждый коврик на место его укладки. Принимая решение купить коврики EVA (ЭВА) в Беларуси вы сами определяете стиль отделки, который сделает вашу машину лучше.",
                Weight = 1650,
                Cost = new Cost
                {
                    Price = (decimal)180.30,
                    CostDelivery = 5,
                    TimeDelivery = "4 дня"
                },
                DetailStore = new DetailStore { Amount = 8}
            },new Detail
            {
                Name = "Воздушный фильтр",
                Img = "фильтр.png",
                Year = "2022",
                Description = "Современный автомобиль состоит из множества различных устройств, которые в большей или меньшей степени влияют на полноценную работу транспортного средства. Существуют такие детали, которые, на первый взгляд, могли бы показаться совсем не обязательными и не нужными. Тем не менее, в большинстве случаев мнения такого рода являются ошибочными, так как именно маленькие детали составляют единую великую конструкцию. Именно одной из таких деталей и является фильтр, посредством которого происходит очистка множества систем от несанкционированного загрязнения.\n\nSource: https://auto.today/bok/3179-chto-takoe-filtr-i-kakie-oni-byvayut.html\n© Auto.Today",
                Weight = 440,
                Cost = new Cost
                {
                    Price = (decimal)25.50,
                    CostDelivery = 1,
                    TimeDelivery = "1 дня"
                },
                DetailStore = new DetailStore { Amount = 10 }
            },
            };

            _context.Details.AddRange(details);
            _context.SaveChanges();
        }
    }
}

