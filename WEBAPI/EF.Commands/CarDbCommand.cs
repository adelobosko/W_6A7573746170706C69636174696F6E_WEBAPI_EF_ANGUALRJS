using System;
using System.Collections.Generic;
using System.Linq;
using AccessModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WEBAPI.EF_MODEL
{
    public static class CarDbCommand
    {
        public static IEnumerable<CarBrand> GetCarBrands(CarDbContext context)
        {
            return context.CarBrands.Include(cb => cb.CarModels).ToList();
        }

        public static CarBrand GetCarBrand(CarDbContext context, Guid guid)
        {
            return context.CarBrands.Include(cb => cb.CarModels).SingleOrDefault(cb => cb.Id == guid);
        }

        public static bool CreateCarBrand(CarDbContext context, NewCarBrand updateCarBrand)
        {
            context.CarBrands.Add(new CarBrand()
            {
                Id = Guid.NewGuid(),
                Name = updateCarBrand.Name,
                Logo = updateCarBrand.Logo,
                Describe = updateCarBrand.Describe
            });
            context.SaveChanges();
            return true;
        }

        public static bool UpdateCarBrand(CarDbContext context, UpdateCarBrand updateCarBrand)
        {
            var carBand = context.CarBrands.SingleOrDefault(cb => cb.Id == updateCarBrand.Id);

            if (carBand == null)
                return false;

            carBand.Name = updateCarBrand.Name;
            carBand.Logo = updateCarBrand.Logo;
            carBand.Describe = updateCarBrand.Describe;
            context.SaveChanges();
            return true;
        }

        public static bool DeleteCarBrand(CarDbContext context, Guid guid)
        {
            var carBand = context.CarBrands.SingleOrDefault(cb => cb.Id == guid);

            if (carBand == null)
                return false;

            context.CarBrands.Remove(carBand);
            context.SaveChanges();
            return true;
        }

        public static IEnumerable<CarModel> GetCarModels(CarDbContext context)
        {
            return context.CarModels.Include(cm => cm.CarPhotos).Include(cm => cm.CarBrand).ToList();
        }

        public static CarModel GetCarModel(CarDbContext context, Guid guid)
        {
            return context.CarModels.Include(cm => cm.CarPhotos).SingleOrDefault(cb => cb.Id == guid);
        }

        public static bool CreateCarModel(CarDbContext context, NewCarModel updateCarModel)
        {
            var carBrand = context.CarBrands.SingleOrDefault(cb => cb.Id == updateCarModel.CarBrandId);
            if (carBrand == null)
            {
                return false;
            }

            var carModel = new CarModel()
            {
                Id = Guid.NewGuid(),
                Name = updateCarModel.Name,
                Photo = updateCarModel.Photo,
                CarBrand = carBrand,
                CarBrandId = carBrand.Id

            };

            context.CarModels.Add(carModel);
            context.SaveChanges();
            return true;
        }

        public static bool UpdateCarModel(CarDbContext context, UpdateCarModel updateCarModel)
        {
            var carBrand = context.CarBrands.SingleOrDefault(cb => cb.Id == updateCarModel.CarBrandId);
            if (carBrand == null)
            {
                return false;
            }

            var carModel = context.CarModels.SingleOrDefault(cb => cb.Id == updateCarModel.Id);

            if (carModel == null)
            {
                return false;
            }

            carModel.Name = updateCarModel.Name;
            carModel.Photo = updateCarModel.Photo;
            carModel.CarBrand = carBrand;
            carModel.CarBrandId = carBrand.Id;
            context.SaveChanges();
            return true;
        }

        public static bool DeleteCarModel(CarDbContext context, Guid guid)
        {
            var carModel = context.CarModels.SingleOrDefault(cb => cb.Id == guid);

            if (carModel == null)
                return false;

            context.CarModels.Remove(carModel);
            context.SaveChanges();
            return true;
        }

        public static IEnumerable<CarPhoto> GetCarPhotos(CarDbContext context)
        {
            return context.CarPhotos.ToList();
        }

        public static CarPhoto GetCarPhoto(CarDbContext context, Guid guid)
        {
            return context.CarPhotos.SingleOrDefault(cb => cb.Id == guid);
        }

        public static bool CreateCarPhoto(CarDbContext context, NewCarPhoto newCarPhoto)
        {
            var carModel = context.CarModels.SingleOrDefault(cb => cb.Id == newCarPhoto.CarModelId);
            if (carModel == null)
            {
                return false;
            }

            var carPhoto = new CarPhoto()
            {
                Id = Guid.NewGuid(),
                Photo = newCarPhoto.Photo,
                CarModel = carModel,
                CarModelId = carModel.Id

            };

            context.CarPhotos.Add(carPhoto);
            context.SaveChanges();
            return true;
        }

        public static bool UpdateCarPhoto(CarDbContext context, UpdateCarPhoto newCarPhoto)
        {
            var carModel = context.CarModels.SingleOrDefault(cb => cb.Id == newCarPhoto.CarModelId);
            if (carModel == null)
            {
                return false;
            }

            var carPhoto = context.CarPhotos.SingleOrDefault(cb => cb.Id == newCarPhoto.Id);

            if (carPhoto == null)
            {
                return false;
            }

            carPhoto.Photo = newCarPhoto.Photo;
            carPhoto.CarModel = carModel;
            carPhoto.CarModelId = carModel.Id;
            context.SaveChanges();
            return true;
        }

        public static bool DeleteCarPhoto(CarDbContext context, Guid guid)
        {
            var carPhoto = context.CarPhotos.SingleOrDefault(cb => cb.Id == guid);

            if (carPhoto == null)
                return false;

            context.CarPhotos.Remove(carPhoto);
            context.SaveChanges();
            return true;
        }

        public static void InitializeDb(CarDbContext context)
        {
            //https://auto.24tv.ua/ru/tag/brandList/
            var bmw = new CarBrand()
            {
                Id = Guid.NewGuid(),
                Name = "BMW",
                Logo = "https://auto.24tv.ua/resources/photos/tag/201801/32.png",
                Describe =
                    "В немецкий концерн BMW AG входят бренды BMW, Mini и Rolls-Royce. Украинцы называют марку этих авто \"БэЭмВэ\", хотя некоторые говорят на американский манер \"БиЕмДаблЮ\". Компания BMW (БМВ) была основана в 1916 г. в Мюнхене (Германия, земля Бавария) как завод авиационных двигателей. В 1923 г. фабрика выпускает свой первый мотоцикл, пять лет спустя BMW начинает производить небольшой автомобильчик под названием Dixi. Главным отличием автомобилей BMW является техническое совершенство, спортивный характер и удовольствие от вождения. Спортивное подразделение производит автомобили с пометкой \"М\". Модельный ряд легковых автомобилей БМВ состоит из моделей, которые обозначаются тремя цифрами (первая - название серии), модели с Х в начале - кроссоверы. С пометкой \"i\" выпускаются электромобили."
            };
            var citroen = new CarBrand()
            {
                Id = Guid.NewGuid(),
                Name = "Citroen",
                Logo = "https://auto.24tv.ua/resources/photos/tag/201801/36.png",
                Describe = "Citroën (Ситроен) - французская автомобильная компания, основанная в 1919 году предпринимателем по имени Андре Ситроен. С 1976 года входит в концерн Peugeot-Citroën (PSA). Штаб-квартира компании находится в Париже. Андре Ситроен начал свою деятельность с производства шестерен для паровозных двигателей и других подобных деталей. Шестерни имели особую коническую форму и именно они изображены на логотипе компании. Предприимчивый Ситроен интересовался различными механическими приборами, а после визита на завод Форда в США, вместе с партнером Жюлем Саломоном основал производство и в 1919 году начал выпуск автомобилей, наметив себе цель выпускать по 100 автомобилей ежедневно и сделать их доступными и массовыми. Первым серийным автомобилем марки стал Citroën А с двигателем объемом 1,3 литра мощностью 10 л.с. Доступная машина имела огромный успех на рынке, что способствовало дальнейшему развитию компании и расширению модельного ряда. В 1934 году Citroën вывел на рынок модель Traction Avant, которая впоследствии стала бестселлером на европейском рынке и выпускалась до 1957 года. В свое время также были популярны Citroën H Van, 2CV, DS, и CX, BX. Некоторые модели марки, как и последние три, оборудовались гидропневматической подвеской. В начале 1920-х Citroën начал выпуск таксомоторов и через десять лет его логотип был на девяти из десяти такси в Париже. Еще один интересный факт из истории марки: Citroën DS-19, выпущенный в 1968 году, имел поворотные фары. А еще Андре Ситроен был первым, кто \"засветил\" Эйфелеву башню, оборудовав ее 125 тысячами лампочек для своей рекламы. Семидесятые отличились для Citroën финансовыми трудностями и двумя альянсами: сначала с Fiat, а затем с Peugeot. Тогда же, в 1976 году, компания оборвала связи со своим основным инвестором - шинным гигантом Michelin. Citroën имеет спортивное подразделение Citroën Racing. Заводская команда пять раз подряд побеждала в чемпионате по ралли-рейдам в 1993-1997 годах. Citroën имеет четыре победы в Ралли Дакар, 8 чемпионских кубков WRC и многочисленных внедорожных гонках. В 2009 году Citroën представила дочернюю марку DS Automobiles или DS, под которой выпускаются автомобили класса премиум. В 2017 году Citroën продала 992 тысячи автомобилей, добыв альянсу PSA 1,929 миллиардов евро."
            };
            var bmwx5 = new CarModel()
            {
                Id = Guid.NewGuid(),
                Name = "BMW X5 (G05) 2018",
                Photo = "https://auto.24tv.ua/resources/photos/tag/201810/12551a3a6649-87f1-4ace-8346-dda951caa5ea.png",
                CarBrand = bmw,
                CarBrandId = bmw.Id
            };

            context.CarBrands.Add(bmw);
            context.CarBrands.Add(citroen);
            context.CarModels.Add(bmwx5);
            context.CarPhotos.AddRange(new CarPhoto()
                {
                    Id = Guid.NewGuid(),
                    Photo = "https://auto.24tv.ua/resources/photos/tag/700x372_DIR/201810/1255e69390c4-1624-45ac-ba67-ad4f843457d4.png",
                    CarModel = bmwx5,
                    CarModelId = bmwx5.Id
                }, new CarPhoto()
                {
                    Id = Guid.NewGuid(),
                    Photo = "https://auto.24tv.ua/resources/photos/tag/700x372_DIR/201810/125584cd4f3c-0e0c-4bf1-aeae-ee07c577924f.png",
                    CarModel = bmwx5,
                    CarModelId = bmwx5.Id
                }, new CarPhoto()
                {
                    Id = Guid.NewGuid(),
                    Photo = "https://auto.24tv.ua/resources/photos/tag/700x372_DIR/201810/125516a42b36-10d1-46c3-9fc4-178a0ce7fede.png",
                    CarModel = bmwx5,
                    CarModelId = bmwx5.Id
                });

            context.SaveChanges();
        }
    }
}
