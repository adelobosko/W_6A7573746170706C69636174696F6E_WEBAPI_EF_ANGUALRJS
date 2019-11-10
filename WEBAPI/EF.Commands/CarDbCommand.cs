﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccessModel;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPI.EF_MODEL
{
    public static class CarDbCommand
    {
        public static void IntitializeDb(CarDbContext context)
        {
            if (context.CarBrands.Any()) return;

            context.CarBrands.Add(new CarBrand()
            {
                Id = Guid.NewGuid(),
                Name = "BMW",
                Logo = "https://auto.24tv.ua/resources/photos/tag/201801/32.png",
                Describe = "В немецкий концерн BMW AG входят бренды BMW, Mini и Rolls-Royce. Украинцы называют марку этих авто \"БэЭмВэ\", хотя некоторые говорят на американский манер \"БиЕмДаблЮ\". Компания BMW (БМВ) была основана в 1916 г. в Мюнхене (Германия, земля Бавария) как завод авиационных двигателей. В 1923 г. фабрика выпускает свой первый мотоцикл, пять лет спустя BMW начинает производить небольшой автомобильчик под названием Dixi. Главным отличием автомобилей BMW является техническое совершенство, спортивный характер и удовольствие от вождения. Спортивное подразделение производит автомобили с пометкой \"М\". Модельный ряд легковых автомобилей БМВ состоит из моделей, которые обозначаются тремя цифрами (первая - название серии), модели с Х в начале - кроссоверы. С пометкой \"i\" выпускаются электромобили."
            });

            context.CarBrands.Add(new CarBrand()
            {
                Id = Guid.NewGuid(),
                Name = "Citroen",
                Logo = "https://auto.24tv.ua/resources/photos/tag/201801/36.png",
                Describe = "Citroën (Ситроен) - французская автомобильная компания, основанная в 1919 году предпринимателем по имени Андре Ситроен. С 1976 года входит в концерн Peugeot-Citroën (PSA). Штаб-квартира компании находится в Париже. Андре Ситроен начал свою деятельность с производства шестерен для паровозных двигателей и других подобных деталей. Шестерни имели особую коническую форму и именно они изображены на логотипе компании. Предприимчивый Ситроен интересовался различными механическими приборами, а после визита на завод Форда в США, вместе с партнером Жюлем Саломоном основал производство и в 1919 году начал выпуск автомобилей, наметив себе цель выпускать по 100 автомобилей ежедневно и сделать их доступными и массовыми. Первым серийным автомобилем марки стал Citroën А с двигателем объемом 1,3 литра мощностью 10 л.с. Доступная машина имела огромный успех на рынке, что способствовало дальнейшему развитию компании и расширению модельного ряда. В 1934 году Citroën вывел на рынок модель Traction Avant, которая впоследствии стала бестселлером на европейском рынке и выпускалась до 1957 года. В свое время также были популярны Citroën H Van, 2CV, DS, и CX, BX. Некоторые модели марки, как и последние три, оборудовались гидропневматической подвеской. В начале 1920-х Citroën начал выпуск таксомоторов и через десять лет его логотип был на девяти из десяти такси в Париже. Еще один интересный факт из истории марки: Citroën DS-19, выпущенный в 1968 году, имел поворотные фары. А еще Андре Ситроен был первым, кто \"засветил\" Эйфелеву башню, оборудовав ее 125 тысячами лампочек для своей рекламы. Семидесятые отличились для Citroën финансовыми трудностями и двумя альянсами: сначала с Fiat, а затем с Peugeot. Тогда же, в 1976 году, компания оборвала связи со своим основным инвестором - шинным гигантом Michelin. Citroën имеет спортивное подразделение Citroën Racing. Заводская команда пять раз подряд побеждала в чемпионате по ралли-рейдам в 1993-1997 годах. Citroën имеет четыре победы в Ралли Дакар, 8 чемпионских кубков WRC и многочисленных внедорожных гонках. В 2009 году Citroën представила дочернюю марку DS Automobiles или DS, под которой выпускаются автомобили класса премиум. В 2017 году Citroën продала 992 тысячи автомобилей, добыв альянсу PSA 1,929 миллиардов евро."
            });
            context.SaveChanges();
        }

        public static IEnumerable<CarBrand> GetCarBrands(CarDbContext context)
        {
            return context.CarBrands.ToList();
        }

        public static CarBrand GetCarBrand(CarDbContext context, Guid guid)
        {
            return context.CarBrands.SingleOrDefault(cb => cb.Id == guid);
        }

        public static IActionResult CreateCarBrand(CarDbContext context, NewCarBrand newCarBrand)
        {
            context.CarBrands.Add(new CarBrand()
            {
                Id = Guid.NewGuid(),
                Name = newCarBrand.Name,
                Logo = newCarBrand.Logo,
                Describe = newCarBrand.Describe
            });
            context.SaveChanges();
            return new OkResult();
        }

        public static IActionResult UpdateCarBrand(CarDbContext context, Guid guid, NewCarBrand newCarBrand)
        {
            var carBand = context.CarBrands.SingleOrDefault(cb => cb.Id == guid);

            if (carBand == null)
                return new NotFoundObjectResult(guid);

            carBand.Name = newCarBrand.Name;
            carBand.Logo = newCarBrand.Logo;
            carBand.Describe = newCarBrand.Describe;
            context.SaveChanges();
            return new OkResult();
        }

        public static IActionResult DeleteCarBrand(CarDbContext context, Guid guid)
        {
            var carBand = context.CarBrands.SingleOrDefault(cb => cb.Id == guid);

            if (carBand == null)
                return new NotFoundObjectResult(guid);

            context.Remove(carBand);
            context.SaveChanges();
            return new OkResult();
        }
    }
}
