// Problem 1
let salaries = {
  John: 100,
  Ann: 160,
  Pete: 130
};

let sum = 0;

for (let key in salaries) {
  sum += salaries[key];
}

console.log(sum);

// Problem 2
function multiplyNumeric(obj) {
  for (let key in obj) {
    if (typeof obj[key] === 'number') {
      obj[key] *= 2;
    }
  }
}

// Example usage:
let menu = {
  width: 200,
  height: 300,
  title: "My menu"
};

multiplyNumeric(menu);

console.log(menu); 
// height
// : 
// 600
// title
// : 
// "My menu"
// width
// : 
// 400

// Problem 3
function checkEmailId(str) {
	// Handle non-string inputs
  if (typeof str !== 'string') {
    return false;
  }

  const lowerStr = str.toLowerCase();
  const atIndex = lowerStr.indexOf('@');
  const dotIndex = lowerStr.indexOf('.');

  // If there's no @ or .
  if (atIndex === -1 || dotIndex === -1) {
    return false;
  }

  // '@' comes after '.' or is at the same position
  if (atIndex >= dotIndex) {
     return false;
  }

  // No character between '@' and '.'
  if (dotIndex - atIndex <= 1){
    return false;
  }

  // All conditions are met
  return true;
}

console.log(checkEmailId("hello@world.com")); // true
console.log(checkEmailId("Test@Example.Com")); // true (case-insensitive)
console.log(checkEmailId("hello.world@com")); // false ('@' after '.')
console.log(checkEmailId("helloworld.com")); // false (missing '@')
console.log(checkEmailId("hello@com"));	// false (missing '.')
console.log(checkEmailId("hello@.com"));	//false (no characters between '@' and '.')
console.log(checkEmailId("123")); //false (not an email)
console.log(checkEmailId(123)); //false (non string input)

// Problem 4
function truncate(str, maxlength) {
  if (str.length <= maxlength) {
    return str;
  } else {
    return str.slice(0, maxlength - 3) + "...";
  }
}

console.log(truncate("1234567890|1234567890|1234567890", 20));

// Problem 5
// Create an array styles with items “James” and “Brennie”
let styles = ["James", "Brennie"];
console.log(styles);

// Append “Robert” to the end
styles.push("Robert");
console.log(styles);

// Replace the value in the middle by “Calvin”. 
// Your code for finding the middle value should work for any
// arrays with odd length
const middleIndex = Math.floor(styles.length / 2);
styles[middleIndex] = "Calvin";
console.log(styles);

// 4. Remove the first value of the array and show it.
const removedItem = styles.shift();
console.log(removedItem);
console.log(styles);

// 5. Prepend Rose and Regal to the array.
styles.unshift("Rose", "Regal");
console.log(styles);

