function getLastElements(arr, countElements = 1)
{
  if (arr instanceof Array)
  {
    let array = arr.slice(-countElements);
    if (array.length == 1)
    {
      return array[0];
    }
    
    return array;
  }

  return null;
}

console.log(getLastElements([7, 9, 0, -2]));
console.log(getLastElements([7, 9, 0, -2], 3));
console.log(getLastElements([7, 9, 0, -2], 6));