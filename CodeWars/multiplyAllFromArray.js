function grow(x){
        let sum=1;
        x.forEach((num)=>sum*=num);
        return sum;
      }

//Simplified version:
function grow(x){
        return x.reduce((result, nextElement) => result*nextElement);
      }