// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.

"use strict"

const ratings = document.querySelectorAll('.rating');
if (ratings.length > 0) {
    initRatings();
}
//Основная функция
function initRatings() {
    let ratingActive, ratingValue;
    for (let index = 0; index < ratings.length; index++) {
        const rating = ratings[index];
        initRating(rating);
    }

    // Инициализируем конкретный рейтинг
    function initRating(rating) {
        initRatingVars(rating);
        setRatingActiveWidth();
        if (rating.classList.contains('rating_set')) {
            setRating(rating);
        }
    }

    // Инициализация переменных
    function initRatingVars(rating) {
        ratingActive = rating.querySelector('.rating_active');
        ratingValue = rating.querySelector('.rating_value');
    }

    // Изменяем ширину активных звёзд
    function setRatingActiveWidth(index = ratingValue.innerHTML) {
        const ratingActiveWidth = index / 0.1;
        ratingActive.style.width = `${ratingActiveWidth}%`;
    }
    function setRating(rating) {
        const ratingItems = rating.querySelectorAll('.rating_item');
        for (let index = 0; index < ratingItems.length; index++) {
            const ratingItem = ratingItems[index];
            ratingItem.addEventListener("mouseenter", function (e) {
                // Обновление переменных
                initRatingVars(rating);
                // Обновление активных звёзд
                setRatingActiveWidth(ratingItem.value);
            });
            ratingItem.addEventListener("mouseleave", function (e) {
                // Обновление активных звёзд
                setRatingActiveWidth();
            });
            ratingItem.addEventListener("click", function (e) {
                // Обновление переменных
                initRatingVars(rating);
                ratingValue.innerHTML = index + 1;
                setRatingActiveWidth();

            });
        }
    }
}