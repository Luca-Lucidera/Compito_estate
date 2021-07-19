const riotAPI = '***************************'; //Valore della api Key (si resetta ogni giorno)

async function findAccount() {
    var index = document.getElementById("regione").selectedIndex;
    var regione = '';
    switch (index) {
        case 0:
            regione = 'EUW1';
            break;
        case 1:
            regione = 'JP1';
            break;
        case 2:
            regione = 'KR';
            break;
        case 3:
            regione = 'NA1';
            break;
        case 4:
            regione = 'OC1';
            break;
    }
    var nomeSummoner = document.getElementById("nomeEvocatore").value;
    var oggetto = await fetch(`https://cors-anywhere.herokuapp.com/https://${regione}.api.riotgames.com/lol/summoner/v4/summoners/by-name/${nomeSummoner}?api_key=${riotAPI}`)
    var json = await oggetto.text();
    console.log(json);
}