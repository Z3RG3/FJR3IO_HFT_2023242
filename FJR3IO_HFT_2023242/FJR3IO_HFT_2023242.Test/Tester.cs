using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FJR3IO_HFT_2023242.Logic;
using FJR3IO_HFT_2023242.Models;
using FJR3IO_HFT_2023242.Repository;
using NUnit.Framework;
using Moq;


namespace FJR3IO_HFT_2023242.Test
{
    [TestFixture]
    public class Tester
    {
        MotorcycleLogic motorcycleLogic;
        Mock<IRepository<Motorcycle>> mockMotorcycleRepository;

        [SetUp]
        public void Init()
        {
            Manufacturer fakeManufacturer1 = new Manufacturer()
            {
                ManufacturerID = 1,
                ManufacturerName = "ManufacturerTest1"
            };
            Manufacturer fakeManufacturer2 = new Manufacturer()
            {
                ManufacturerID = 2,
                ManufacturerName = "ManufacturerTest2"
            };
            Manufacturer fakeManufacturer3 = new Manufacturer()
            {
                ManufacturerID = 3,
                ManufacturerName = "ManufacturerTest3"
            };
            Manufacturer fakeManufacturer4 = new Manufacturer()
            {
                ManufacturerID = 4,
                ManufacturerName = "ManufacturerTest4"
            };
            Manufacturer fakeManufacturer5 = new Manufacturer()
            {
                ManufacturerID = 5,
                ManufacturerName = "ManufacturerTest5"
            };
            Manufacturer fakeManufacturer6 = new Manufacturer()
            {
                ManufacturerID = 6,
                ManufacturerName = "ManufacturerTest6"
            };
            Manufacturer fakeManufacturer7 = new Manufacturer()
            {
                ManufacturerID = 7,
                ManufacturerName = "ManufacturerTest7"
            };
            Manufacturer fakeManufacturer8 = new Manufacturer()
            {
                ManufacturerID = 8,
                ManufacturerName = "ManufacturerTest8"
            };
            Manufacturer fakeManufacturer9 = new Manufacturer()
            {
                ManufacturerID = 9,
                ManufacturerName = "ManufacturerTest9"
            };
            Manufacturer fakeManufacturer10 = new Manufacturer()
            {
                ManufacturerID = 10,
                ManufacturerName = "ManufacturerTest10"
            };
            Garage fakeGarage1 = new Garage()
            {
                GarageID = 1,
                GarageName = "GarageTest1"
            };
            Garage fakeGarage2 = new Garage()
            {
                GarageID = 2,
                GarageName = "GarageTest2"
            };
            Garage fakeGarage3 = new Garage()
            {
                GarageID = 3,
                GarageName = "GarageTest3"
            };
            Garage fakeGarage4 = new Garage()
            {
                GarageID = 4,
                GarageName = "GarageTest4"
            };
            Garage fakeGarage5 = new Garage()
            {
                GarageID = 5,
                GarageName = "GarageTest5"
            };
            Garage fakeGarage6 = new Garage()
            {
                GarageID = 6,
                GarageName = "GarageTest6"
            };
            Garage fakeGarage7 = new Garage()
            {
                GarageID = 7,
                GarageName = "GarageTest7"
            };
            Garage fakeGarage8 = new Garage()
            {
                GarageID = 8,
                GarageName = "GarageTest8"
            };
            Garage fakeGarage9 = new Garage()
            {
                GarageID = 9,
                GarageName = "GarageTest9"
            };
            Garage fakeGarage10 = new Garage()
            {
                GarageID = 10,
                GarageName = "GarageTest10"
            };

            var input = new List<Motorcycle>()
    {
        new Motorcycle()
        {
            MotorcycleID = 1,
            Model = "MotorcycleTest1",
            ManufacturingYear = 2023,
            Manufacturer = fakeManufacturer1,
            ManufacturerID = 1,
            Garage = fakeGarage2,
            GarageID = 2
        },
        new Motorcycle()
        {
            MotorcycleID = 2,
            Model = "MotorcycleTest2",
            ManufacturingYear = 2023,
            Manufacturer = fakeManufacturer3,
            ManufacturerID = 3,
            Garage = fakeGarage1,
            GarageID = 1
        },
        new Motorcycle()
        {
            MotorcycleID = 3,
            Model = "MotorcycleTest3",
            ManufacturingYear = 2023,
            Manufacturer = fakeManufacturer2,
            ManufacturerID = 2,
            Garage = fakeGarage3,
            GarageID = 3
        },
        new Motorcycle()
        {
            MotorcycleID = 4,
            Model = "MotorcycleTest4",
            ManufacturingYear = 2023,
            Manufacturer = fakeManufacturer6,
            ManufacturerID = 6,
            Garage = fakeGarage4,
            GarageID = 4
        },
        new Motorcycle()
        {
            MotorcycleID = 5,
            Model = "MotorcycleTest5",
            ManufacturingYear = 2023,
            Manufacturer = fakeManufacturer4,
            ManufacturerID = 4,
            Garage = fakeGarage5,
            GarageID = 5
        },
        new Motorcycle()
        {
            MotorcycleID = 6,
            Model = "MotorcycleTest6",
            ManufacturingYear = 2023,
            Manufacturer = fakeManufacturer5,
            ManufacturerID = 5,
            Garage = fakeGarage8,
            GarageID = 8
        },
        new Motorcycle()
        {
            MotorcycleID = 7,
            Model = "MotorcycleTest7",
            ManufacturingYear = 2023,
            Manufacturer = fakeManufacturer9,
            ManufacturerID = 9,
            Garage = fakeGarage10,
            GarageID = 10
        },
        new Motorcycle()
        {
            MotorcycleID = 8,
            Model = "MotorcycleTest8",
            ManufacturingYear = 2022,
            Manufacturer = fakeManufacturer8,
            ManufacturerID = 8,
            Garage = fakeGarage7,
            GarageID = 7
        },
        new Motorcycle()
        {
            MotorcycleID = 9,
            Model = "MotorcycleTest9",
            ManufacturingYear = 2023,
            Manufacturer = fakeManufacturer7,
            ManufacturerID = 7,
            Garage = fakeGarage6,
            GarageID = 6
        },
        new Motorcycle()
        {
            MotorcycleID = 10,
            Model = "MotorcycleTest10",
            ManufacturingYear = 2023,
            Manufacturer = fakeManufacturer10,
            ManufacturerID = 10,
            Garage = fakeGarage9,
            GarageID = 9
        }
    };
            mockMotorcycleRepository = new Mock<IRepository<Motorcycle>>();
            IQueryable<Motorcycle> MotorcycleQueryable = input.AsQueryable();
            mockMotorcycleRepository.Setup(t => t.ReadAll()).Returns(MotorcycleQueryable);
            motorcycleLogic = new MotorcycleLogic(mockMotorcycleRepository.Object);
        }

        [Test]
        public void MotorcycleCreationWithCorrectTest()
        {
            var sample = new Motorcycle()
            {
                MotorcycleID = 1,
                Model = "Motorcycle1",
                ManufacturingYear = 2023,
                ManufacturerID = 1,
                GarageID = 1
            };
            motorcycleLogic.Create(sample);
            mockMotorcycleRepository.Verify(t => t.Create(sample), Times.Once);
        }

        [Test]
        public void MotorcycleCreationWithIncorrectTest()
        {
            var sample = new Motorcycle()
            {
                MotorcycleID = 1,
                Model = "A",
                ManufacturingYear = 2000,
                ManufacturerID = 1,
                GarageID = 1
            };
            try
            {
                motorcycleLogic.Create(sample);
            }
            catch { }
            mockMotorcycleRepository.Verify(t => t.Create(sample), Times.Never);
        }

        [Test]
        public void ExceptionTest()
        {
            var sample = new Motorcycle()
            {
                MotorcycleID = 1,
                Model = "A",
                ManufacturingYear = 1886,
                ManufacturerID = 1,
                GarageID = 1
            };
            Assert.That(() => motorcycleLogic.Create(sample), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void ReadTest()
        {
            var expected = new Motorcycle()
            {
                MotorcycleID = 3,
                Model = "Motorcycle2",
                ManufacturingYear = 2002,
                ManufacturerID = 3,
                GarageID = 4
            };
            mockMotorcycleRepository.Setup(t => t.Read(3)).Returns(expected);

            var result = motorcycleLogic.Read(3);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ReadTestWithIncorrectID()
        {
            Assert.That(() => motorcycleLogic.Read(235), Throws.TypeOf<ArgumentException>());
        }

        // Working test
        [Test]
        public void GetMotorcycleNumberByManufacturerTest()
        {
            int sum = motorcycleLogic.GetMotorcycleNumberByManufacturer("ManufacturerTest3");
            Assert.That(sum, Is.EqualTo(1));
        }

        [Test]
        public void GetMotorcycleNumberByYearTest()
        {
            int sum = motorcycleLogic.GetMotorcycleNumberByYear(2023);
            Assert.That(sum, Is.EqualTo(9));
        }

        [Test]
        public void GetMotorcyclesModelByManufacturerIDTest() // nem fut
        {
            var result = motorcycleLogic.GetMotorcycleModelByManufacturer("ManufacturerTest1");
            
            var expected = new List<string>()
            {
                "MotorcycleTest1"
            };

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetMotorcycleModelByGarageNameTest() // nem fut
        {
            var result = motorcycleLogic.GetMotorcycleModelByGarageName("GarageTest5");
            var expected = new List<string>()
            {
                "MotorcycleTest5"
            };

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetGarageNameByManufacturerNameTest()
        {
            var result = motorcycleLogic.GetGarageNameByManufacturerName("ManufacturerTest1");
            var expected = new List<string>()
                {
                    "GarageTest2"
                };

            Assert.That(result, Is.EqualTo(expected));
        }

    }
}

