function removeDuplicates(arr){
  if (arr instanceof Array){
    for(let i = 0; i < arr.length; i++)
    {
      for (let j = i + 1; j < arr.length; j++)
      {
        if (arr[i] == arr[j])
        {
          arr.splice(j, 1);
          j = i + 1;
        }
      }
    }
  }

  return arr;
}

console.log(removeDuplicates([1, 1, 2, 3, 4, 3, 2]));