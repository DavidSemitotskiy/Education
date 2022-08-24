function getLastElements(arr, countElements = 1)
{
  if (arr instanceof Array){
    return arr.slice(-countElements);
  }

  return null;
}

console.log(getLastElements([7, 9, 0, -2]));
console.log(getLastElements([7, 9, 0, -2], 3));
console.log(getLastElements([7, 9, 0, -2], 6));