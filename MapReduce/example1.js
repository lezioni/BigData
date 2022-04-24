const persone = require('./Persone_eta_altezza.json')

// Map - Estraggo le informazioni necessarie
const data = persone.map(function(item) {
  return { "eta": item.Age, "altezza": item.Height }
});

let selected = 0;

// Reduce - Calcolo i risultati
const media = data.reduce(function (result, item, index, values) {
  if (item.eta > 35) 
  {
    selected++;
    result += item.altezza;
  }
  
  if (index == values.length -1) 
  {
    result = result / selected;
  }
    
  return result;
}, 0);

console.log('altezza media degli over 35: ' + media);
