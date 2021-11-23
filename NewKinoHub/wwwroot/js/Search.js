////window.onload = () => {
////    let input = document.querySelector("#searchin");
////    input.oninput = function () {
////        let value = this.value.trim();
////        let list = document.querySelectorAll('.item_films li');

////        value
////            ? list.forEach(elem => {
////                elem.innerText.search(value) == -1
////                    ? elem.classList.add('hide')
////                    : elem.classList.remove('hide');
////            })
////            : list.forEach(elem => {
////                elem.classList.remove('hide');
////            });
////    };
////};
const defaultSelect = () => {
    const element = document.querySelector('.js-chosen');
    const choices = new Choices(element);
};
defaultSelect();
