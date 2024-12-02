using Domain.EntityModels.Additional.Common;
using Domain.EntityModels.Main;
using Domain.EntityModels.Products.ComputerParts;
using Domain.EntityModels.Products.OtherDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.AppModel;

using System.Resources;
using Domain.EntityModels.Additional.ComputerParts;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace Domain.ViewModels
{
    public class ProductVm
    {
        //Non product fields
        public readonly string MainImageUrl;
        public readonly ViewMode ViewMode;
        public readonly ProductType ProductType;
        public readonly int AverageRate;
        public readonly int ReviewsCounter;

        //Shared fields
        public readonly string? Name; // All
        public readonly string? Producer; //Case
        public readonly int? GuarantyTime; //Case
        public readonly string? Color; // Case
        public readonly string? AdditionalInfo; //Casse
        public readonly bool? Lighting;
        public readonly int? DiskSize; //Laptop, DesktopComputer, DiskDrive
        public readonly string? DiskType; //Laptop, DesktopComputer, DiskDrive   
        public readonly string? Gpu; //Desktop, laptop, GraphicCard
        public readonly string? PowerSupplyFormat; //PowerSupply and Cas
        public readonly int? Frequency; //Processor and Ram
        public readonly string? RamType; // Desktop computer, laptops and Ram
        public readonly string? Connectivity; //Keyboard
        public readonly string? Destination; //Keyboard
        public readonly decimal? ScreenDiagonal; //Monitor, smartphone
        public readonly string? Processor; //DesktopComputer, laptop, smartphone
        public readonly int? RamSize; //DesktopComputer, laptop, smartphone
        public readonly string? OperatingSystem; //DesktopComputer, laptop, smartphone
        public readonly int? BatteryCapacity; //Laptop, smartphone

        //Case
        public readonly string? MotherBoardsFormats;
        public readonly string?  CaseType;

        //Desktop computer and laptops
        public readonly int? GpuMemorySize; //Desktop computer
        public readonly string? Resolution; //Laptop, smartphone

        //Disk 
        int? ReadSpeed;
        public readonly int? WriteSpeed;
        public readonly string DiskDriveInterface;

        //GraphicCard
        public readonly string? GraphicCardSerie;
        public readonly string? MemoryType;
        public readonly int? MemorySize;
        public readonly int? CoreClock;
        public readonly int? MemoryClock;
        public readonly bool? RayTracing;


        //Motherboard
        public readonly string? Format;
        public readonly string? ProcessorSocket;
        public readonly string? Chipset;
        public readonly string? SupportedMemoryTypes;
        public readonly string? ProcesorArchitecture;
        public readonly string? SupportedProcessorFamilies;
        public readonly int? RamSlots;

        //PowerSupply
        public readonly int? MaximalPower;
        public readonly string? Certificate;
        public readonly string? Efficiency;
        public readonly string? Connectors;
        public readonly string? PowerSupplyProtectorsFeatures;

        //Processor
        public readonly int? Cores;
        public readonly int? Threads;
        public readonly int? CacheSize;
        public readonly bool? IntegratedGpu;
        public readonly bool? hasCoolerIncluded;

        //Ram
        public readonly int? TotalSize;
        public readonly int? SizePerChips;
        public readonly int? ChipsAmount;

        //Keyboard
        public readonly string? SwitchType;
        public readonly string? Profile;
        public readonly bool? NumericKeypad;

        //Monitor
        public readonly int? ScreenRefreshRate;
        public readonly string? ScreenType;
        public readonly bool? BuiltInSpeakers;
        public readonly decimal? Latency;

        //Mouse
        public readonly int? ButtonsAmount;
        public readonly string? SensorType;
        public readonly int? Dpi;

        //Printer
        public readonly bool? DuplexPrinting;
        public readonly string? PrintTechnology;
        public readonly string? MaxPrintingResolution;
        public readonly string? SupportedMediaTypes;
        public readonly string? SupportedMediaFormats;

        //Smartphone
        public readonly string? BackCamera;

        //Televisor
        public readonly string? ExternalPorts;
        public readonly bool? HasSmartTv;

        public ProductVm(Case product, string mainImageUrl)
        {
            MainImageUrl = mainImageUrl;
            Name = product.Name;
            ProductType = product.ProductType;
            AverageRate = product.AverageRate;
            ReviewsCounter = product.Reviews.Count;

            Producer = product.Producer;
            GuarantyTime = product.GuarantyTime;
            Color = product.Color;
            MotherBoardsFormats = product.MotherBoardFormats;
            PowerSupplyFormat = product.PowerSupplyFormat;
            CaseType = product.CaseType.ToString();
        }
        public ProductVm(DiskDrive product, string mainImageUrl)
        {
            MainImageUrl = mainImageUrl;
            Name = product.Name;
            ProductType = product.ProductType;
            AverageRate = product.AverageRate;
            ReviewsCounter = product.Reviews.Count;

            Producer = product.Producer;
            GuarantyTime = product.GuarantyTime;
            DiskSize = product.DiskSize;
            ReadSpeed = product.ReadSpeed;
            WriteSpeed = product.WriteSpeed;
            DiskType = product.DiskDriveType.ToString();  
            DiskDriveInterface = product.DiskDriveInterface.ToString();
        }
        public ProductVm(GraphicCard product, string mainImageUrl)
        {
            MainImageUrl = mainImageUrl;
            Name = product.Name;
            ProductType = product.ProductType;
            AverageRate = product.AverageRate;
            ReviewsCounter = product.Reviews.Count;

            Producer = product.Producer;
            Gpu = product.Gpu;
            GraphicCardSerie = product.GraphicCardSerie;
            MemoryType = product.MemoryType;
            MemorySize = product.MemorySize;
            CoreClock = product.CoreColck;
            MemoryClock = product.MemoryClock;
            RayTracing = product.RayTracing;
        }
        public ProductVm(MotherBoard product, string mainImageUrl)
        {
            MainImageUrl = mainImageUrl;
            Name = product.Name;
            ProductType = product.ProductType;
            AverageRate = product.AverageRate;
            ReviewsCounter = product.Reviews.Count;

            Format = product.Format;
            ProcessorSocket = product.ProcessorSocket;
            Chipset = product.Chipset;
            SupportedMemoryTypes = product.SupportedMemoryTypes;
            ProcesorArchitecture = product.ProcesorArchitecture;
            SupportedProcessorFamilies = product.SupportedProcessorFamilies;
            RamSlots = product.RamSlots;

        }
        
        public ProductVm(PowerSupply product, string mainImageUrl)
        {
            MainImageUrl = mainImageUrl;
            Name = product.Name;
            ProductType = product.ProductType;
            AverageRate = product.AverageRate;
            ReviewsCounter = product.Reviews.Count;

            Producer = product.Producer;
            MaximalPower = product.MaximalPower;
            Certificate = product.Certyficate;
            PowerSupplyFormat = product.PowerSupplyFormat;
            Efficiency = product.Efficiency;
            Connectors = product.Connectors;
            PowerSupplyProtectorsFeatures = product.PowerSupplyProtectorsFeatures;
        }

        public ProductVm(Processor product, string mainImageUrl)
        {
            MainImageUrl = mainImageUrl;
            Name = product.Name;
            ProductType = product.ProductType;
            AverageRate = product.AverageRate;
            ReviewsCounter = product.Reviews.Count;

            Producer = product.Producer;
            Cores = product.Cores;
            Threads = product.Threads;
            Frequency = product.Frequency;
            CacheSize = product.CacheSize;
            IntegratedGpu = product.IntegratedGpu;
            hasCoolerIncluded = product.HasCoolerIncluded;
            ProcessorSocket = product.ProcessorSocket;
        }

        
        public ProductVm(Ram product, string mainImageUrl)
        {
            MainImageUrl = mainImageUrl;
            Name = product.Name;
            ProductType = product.ProductType;
            AverageRate = product.AverageRate;
            ReviewsCounter = product.Reviews.Count;

            Producer = product.Producer;
            Color = product.Color;
            Frequency = product.Frequency;
            TotalSize = product.TotalSize;
            SizePerChips = product.SizePerChips;
            ChipsAmount = product.ChipsAmount;
            RamType = product.RamType;
            GuarantyTime = product.GuarantyTime;
        }
        public ProductVm(DesktopComputer product, string mainImageUrl)
        {
            MainImageUrl = mainImageUrl;
            Name = product.Name;
            ProductType = product.ProductType;
            AverageRate = product.AverageRate;
            ReviewsCounter = product.Reviews.Count;

            Processor = product.Processor;
            Gpu = product.Gpu;
            GpuMemorySize = product.GpuMemorySize;
            RamType = product.RamType;
            RamSize = product.RamSize;
            DiskType = product.DiskType.ToString();
            DiskSize = product.DiskSize; 
            OperatingSystem = product.OperatingSystem;

        }
        public ProductVm(Keyboard product, string mainImageUrl)
        {
            MainImageUrl = mainImageUrl;
            Name = product.Name;
            ProductType = product.ProductType;
            AverageRate = product.AverageRate;
            ReviewsCounter = product.Reviews.Count;

            Producer = product.Producer;
            Color = product.Color;
            Destination = product.Destination;
            SwitchType = product.SwitchType;
            Profile = product.Profile;
            Connectivity = product.Connectivity;
            Lighting = product.Lighting;
            NumericKeypad = product.NumericKeypad;
            GuarantyTime = product.GuarantyTime;
        }
        public ProductVm(Laptop product, string mainImageUrl)
        {
            MainImageUrl = mainImageUrl;
            Name = product.Name;
            ProductType = product.ProductType;
            AverageRate = product.AverageRate;
            ReviewsCounter = product.Reviews.Count;

            Processor = product.Processor;
            Gpu = product.Gpu;
            RamSize = product.RamSize;
            DiskType = product.DiskType.ToString();
            DiskSize = product.DiskSize;
            OperatingSystem = product.OperatingSystem;
            Resolution = product.Resolution;
            BatteryCapacity = product.BatteryCapacity;
        }

        public ProductVm(MonitorScreen product, string mainImageUrl)
        {
            MainImageUrl = mainImageUrl;
            Name = product.Name;
            ProductType = product.ProductType;
            AverageRate = product.AverageRate;
            ReviewsCounter = product.Reviews.Count;

            Producer = product.Producer;
            ScreenDiagonal = product.ScreenDiagonal;
            ScreenRefreshRate = product.ScreenRefreshRate;
            ScreenType = product.ScreenType;
            BuiltInSpeakers = product.BuiltInSpeakers;
            Latency = product.Latency;
            Color = product.Color;
        }

        public ProductVm(Mouse product, string mainImageUrl)
        {
            MainImageUrl = mainImageUrl;
            ProductType = product.ProductType;
            Name = product.Name;
            AverageRate = product.AverageRate;
            ReviewsCounter = product.Reviews.Count;

            Producer = product.Producer;
            Destination = product.Destination;
            Lighting = product.Lighting;
            ButtonsAmount = product.ButtonsAmount;
            SensorType = product.SensorType;
            Connectivity = product.Connectivity;
            Dpi = product.Dpi;
        }

        public ProductVm(Printer product, string mainImageUrl)
        {
            MainImageUrl = mainImageUrl;
            ProductType = product.ProductType;
            Name = product.Name;
            AverageRate = product.AverageRate;
            ReviewsCounter = product.Reviews.Count;

            Producer = product.Producer;
            Destination = product.Destination;
            DuplexPrinting = product.DuplexPrinting;
            PrintTechnology = product.PrintTechnology;
            MaxPrintingResolution = product.MaxPrintingResolution;
            SupportedMediaTypes = product.SupportedMediaTypes;
            SupportedMediaFormats = product.SupportedMediaFormats;
        }

        public ProductVm(Smartphone product, string mainImageUrl)
        {
            MainImageUrl = mainImageUrl;
            ProductType = product.ProductType;
            Name = product.Name;
            AverageRate = product.AverageRate;
            ReviewsCounter = product.Reviews.Count;

            Producer = product.Producer;
            BackCamera = product.BackCamera;
            Resolution = product.Resolution;
            ScreenDiagonal = product.ScreenDiagonal;
            Processor = product.Processor;
            RamSize = product.RamSize;
            OperatingSystem = product.OperatingSystem;
            BatteryCapacity = product.BatteryCapacity;
        }
        public ProductVm(Televisor product, string mainImageUrl)
        {
            MainImageUrl = mainImageUrl;
            ProductType = product.ProductType;
            Name = product.Name;
            AverageRate = product.AverageRate;
            ReviewsCounter = product.Reviews.Count;

            Producer = product.Producer;
            ScreenRefreshRate = product.ScreenRefreshRate;
            Resolution = product.Resolution;
            ScreenDiagonal = product.ScreenDiagonal;
            ExternalPorts = product.ExternalPorts;
            OperatingSystem = product.OperatingSystem;
            GuarantyTime = product.GuarantyTime;
        }
        public ProductVm() { }

    }
}
