

var request = new XMLHttpRequest();
var requestURL = 'https://mdn.github.io/learning-area/javascript/oojs/json/superheroes.json';

request.open('GET', requestURL);

request.responseType = 'json';

request.send();

request.onload = function () {

    var superHeroes = request.response;

    populateHeader(superHeroes);

    showHeroes(superHeroes);

}

function populateHeader(obj) {
    //creates header element with the name of the squad 
    var h1Title = document.createElement('h1');
    h1Title.textContent = obj['squadName'];

    var originParagraph = document.createElement('p');
    originParagraph.textContent = 'Hometown: ' + obj['homeTown'] + ' // Formed: ' + obj['formed'];

    header.appendChild(h1Title);
    header.appendChild(originParagraph);
}

function showHeroes(obj) {
    var heroMembers = obj['members'];


    for (var i = 0; i < heroMembers.length; i++) {
        var hero = document.createElement('article');
        var heroName = document.createElement('h2');
        heroName.textContent = heroMembers[i]['name'];
        var heroID = document.createElement('p');
        var heroAge = document.createElement('p');
        var heroPowers = document.createElement('p');
        var powerList = document.createElement('ul');
        heroName.textContent = heroMembers[i]['name'];
        heroID.textContent = 'Secret Identity: '+ heroMembers[i]['secretIdentity'];
        heroAge.textContent = 'Age: ' + heroMembers[i]['age'];
        heroPowers.textContent = 'Superpowers: ';
        var powers = heroMembers[i]['powers'];
        for (var j = 0; j < powers.length; j++) {
            var powerItem = document.createElement('li');
            powerItem.textContent = powers[j];
            powerList.appendChild(powerItem);

        }

        hero.appendChild(heroName);
        hero.appendChild(heroID);
        hero.appendChild(heroAge);
        hero.appendChild(heroPowers);
        hero.appendChild(powerList);
        section.appendChild(hero);

    }

    

    //var hero2Name = document.createElement('h2');
    //hero2Name.textContent = heroMembers[1]['name'];

    //var hero3Name = document.createElement('h2');
    //hero3Name.textContent = heroMembers[2]['name'];

    //hero1.appendChild(hero1Name);
    //hero1.appendChild
   
    //section.appendChild(hero2Name);
    //section.appendChild(hero3Name);
}
