function countVowelSymbols(str){
  let count = 0;
  for (let index = 0; index < str.length; index++)
  {
    let symbolUpperCase = str[index].toUpperCase();
    if (symbolUpperCase == "A" || symbolUpperCase == "E"|| symbolUpperCase == "I"
    || symbolUpperCase == "O" || symbolUpperCase == "U" || symbolUpperCase == "Y")
    {
      count++;
    }
  }

  return count;
}

let str = prompt("input text");
alert(`Count of vowel symbols is ${countVowelSymbols(str)}`);