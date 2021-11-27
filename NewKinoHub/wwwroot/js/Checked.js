function CheckedPersonRole(userObj) {
    var actor = document.getElementById("IsActor");
    var director = document.getElementById("IsDirector");
    var screenwriter = document.getElementById("IsSceenwriter");
    var ac = userObj.isActor;
    var dir = userObj.isDirector;
    var scr = userObj.isScreenWriter;
    if (ac == true) {
        actor.checked = true;
    }
    if (dir == true) {
        director.checked = true;
    }
    if (scr == true) {
        screenwriter.checked = true;
    }
}
function CheckedEditFilm(userObj) {
    ChangeType();
    let genre = document.getElementById("Genres");
    let num = document.getElementById("NumOfGenres");
    for (let index = 0; index < userObj.genres.length; index++) {
        genre.options[num.options[index].value - 1].selected = true;
    }
}
function ChangeType() {
    var serial = document.getElementById("serial");
    var select = document.getElementById("type");
    select.addEventListener('change', function () {
        if (select.value == 0)
            serial.hidden = true;
        else
            serial.hidden = false;
    });
}
function ChangeCareer() {
    var careers = document.querySelector('#careers');
    var actorPeople = document.querySelector('#actors');
    var directorPeople = document.querySelector('#directors');
    var screenwriterPeople = document.querySelector('#screenwriters');

    careers.addEventListener('change', function () {
        document.querySelector('.active.people').classList.remove('active');
        if (this.value == 'actors') {
            actorPeople.classList.add('active');
        }
        if (this.value == 'directors') {
            directorPeople.classList.add('active');
        }
        if (this.value == 'screenwriters') {
            screenwriterPeople.classList.add('active');
        }
    });

    var careers1 = document.querySelector('#careers1');

    var actorPeople1 = document.querySelector('#actors1');
    var directorPeople1 = document.querySelector('#directors1');
    var screenwriterPeople1 = document.querySelector('#screenwriters1');

    careers1.addEventListener('change', function () {
        document.querySelector('.active1.people1').classList.remove('active1');
        if (this.value == 'actors1') {
            actorPeople1.classList.add('active1');
        }
        if (this.value == 'directors1') {
            directorPeople1.classList.add('active1');
        }
        if (this.value == 'screenwriters1') {
            screenwriterPeople1.classList.add('active1');
        }
    });
}