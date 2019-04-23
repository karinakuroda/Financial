using _1._3_Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;

namespace _1._4_Data
{
    public class FinancialContext : DbContext
    {
        public static readonly LoggerFactory MyConsoleLoggerFactory = new LoggerFactory(new[] {
            new ConsoleLoggerProvider((category, level) =>
                category == DbLoggerCategory.Database.Command.Name &&
                level==LogLevel.Information,
                true
         )});

        public FinancialContext(DbContextOptions<FinancialContext> options)
          : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<TagCategory> TagCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<TagCategory> tagCategoryList = new List<TagCategory>();

            tagCategoryList.Add(new TagCategory { Id = 0, Name = "None", OperationType = _3_Domain.OperationType.Debit });
            tagCategoryList.Add(new TagCategory { Id = 1, Name = "Hobby", OperationType = _3_Domain.OperationType.Debit });
            tagCategoryList.Add(new TagCategory { Id = 2, Name = "Family", OperationType = _3_Domain.OperationType.Debit });
            tagCategoryList.Add(new TagCategory { Id = 3, Name = "Food", OperationType = _3_Domain.OperationType.Debit });
            tagCategoryList.Add(new TagCategory { Id = 4, Name = "Market", OperationType = _3_Domain.OperationType.Debit });
            tagCategoryList.Add(new TagCategory { Id = 5, Name = "House", OperationType = _3_Domain.OperationType.Debit });
            tagCategoryList.Add(new TagCategory { Id = 6, Name = "Shop", OperationType = _3_Domain.OperationType.Debit });
            tagCategoryList.Add(new TagCategory { Id = 7, Name = "EssentialServices", OperationType = _3_Domain.OperationType.Debit });
            tagCategoryList.Add(new TagCategory { Id = 8, Name = "Transport", OperationType = _3_Domain.OperationType.Debit });
            tagCategoryList.Add(new TagCategory { Id = 9, Name = "ATM", OperationType = _3_Domain.OperationType.Debit });
            tagCategoryList.Add(new TagCategory { Id = 10, Name = "Credit", OperationType = _3_Domain.OperationType.Credit });
            tagCategoryList.Add(new TagCategory { Id = 11, Name = "Health", OperationType = _3_Domain.OperationType.Debit });
            tagCategoryList.Add(new TagCategory { Id = 12, Name = "BrazilAccount", OperationType = _3_Domain.OperationType.Debit });


            List<Tag> tagList = new List<Tag>();
            tagList.Add(new Tag { TagCategoryId = 3, Regex = "restaurante|comida|jeronymo|starbucks|alimentacao|pregaria|padaria|bitoque|pizza|bira dos namorados|bodegao|SAO JORGE 4000-062|CEDILHA VICOSA|A BRAGUISTA|SORTE E SURPRESA|VAGAS BAR|TAVERNA DO ALHO|RITUAL MARAVILHA 4200-162|ADERENTIDEIA|ANTONIO MIRANDA E MAPORTO|BANCO DE PORTUGAL LISBOA|BELSERVICE LISBOA|MIIT|MC DONALDS|MCDONALDS|CAFETARIA|MILLE PASTE|HILDA BARROS LDA RIO TINTO|PRAXIS LDA COIMBRA|TROPICALFOOD LDA TAVEIRO|NATA DA NATA LDA PORTO CONTACTLESS|RESTAUR SOLDOURO LDA3800-168 AVEIRO|FH3 GESTAO REST SA SENH CONTACTLESS|REPUBLICA CHURRASCO PORTO|VITAMINAS - ESTACAO 4900-317 VIANAFORNO PEDRA PORTO|ALI BABA|UNICAMPUS LDA PORTO CONTACTLESS" });
            tagList.Add(new Tag { TagCategoryId = 1, Regex = "tennis|playland|BILHETEIRA|RIDEHIVE.COM|TELEF TRANSP CABO|SOGEVINUS BURMESTER|BLUETICKET|PORTO COMERCIAL PORTO PT" });
            tagList.Add(new Tag { TagCategoryId = 4, Regex = "continente|pingo doce|horta da luz|supermercado|froiz|talho do povo|ANA PAULA VALE LDA MAIA|ANA PAULA VALE UNIP MAIA|KOPKE|MINIPRECO|HIPER POUPANCA|COENTRALIZ IMP EXP|APH UP|LIDL" });
            tagList.Add(new Tag { TagCategoryId = 5, Regex = "ikea|indaqua|nascimento araujo|EDP COMERCIAL|003300000005793179605|NOS Comunicacoe|airbnb|KINDA HOME|0223" });
            tagList.Add(new Tag { TagCategoryId = 6, Regex = "zara|foreva|kiko|tiger|calzedonia|tezenis|worten|DECATHLON|livraria|lello|primark|SEPHORA|EL CORTE INGLES|fnac|SPRINGFIELD PORTO" });
            tagList.Add(new Tag { TagCategoryId = 7, Regex = "vodafone|google play" });
            tagList.Add(new Tag { TagCategoryId = 8, Regex = "OTLIS|MARQUES POMBAL|UBER|TXFY|RYANAIR|RNE|transporte|INTERNATIONALCAR|discovercarhire|CAR RENTAL|WWW.CP.PT|COLEGIO MILITAR LISBOA|COMBIVERDE|PORTO SAO BENTO 4000-069|SANTA APOLONIA LISBOA|JARDIM ZOOLOGICO LISBOA|ANJOS LISBOA|CAIS SODRE LISBOA|TERREIRO DO PACO LISBOA|SALDANHA LISBOA|GENERAL TORRES 4430-000 VILA NGAIA|ORIENTE LISBOA" });
            tagList.Add(new Tag { TagCategoryId = 9, Regex = "LEV ATM" });
            tagList.Add(new Tag { TagCategoryId = 10, Regex = "DEPOSITO NUMERARIO|TRANSFERENCIA - VENCIMENTO|ANUL ENT P/DEP|ENTREGA P/DEPOSITO|transferwise|WA FENIX|TRF MB WAY DE" });
            tagList.Add(new Tag { TagCategoryId = 11, Regex = "FARMACIA" });
            tagList.Add(new Tag { TagCategoryId = 12, Regex = "transferwise" });
            
            modelBuilder.Entity<TagCategory>().HasData(tagCategoryList.ToArray());
            modelBuilder.Entity<Tag>().HasData(tagList.ToArray());

            base.OnModelCreating(modelBuilder);
        }
    }
}
