function checkOnSymbol(arr) {
  if (arr instanceof Array){
    if (arr.length >= 1){
      return arr[0] == "1" || arr[arr.length - 1] == "1";
    }
  }

  return false;
}

console.log(checkOnSymbol([1, 2, 3]));
console.log(checkOnSymbol([2, 1]));
console.log(checkOnSymbol([2, 4]));