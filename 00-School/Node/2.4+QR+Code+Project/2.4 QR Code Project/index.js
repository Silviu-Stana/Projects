import inquirer from 'inquirer';
import { createCanvas } from 'canvas';
import fs from 'fs';
import QRCode from 'qrcode';

// Question array
const questions = [
  {
    type: 'input',
    name: 'url',
    message: "URL to convert to QR code image: ",
  }
];

// Prompt user for the URL
inquirer.prompt(questions).then((answers) => {
  
  const canvas = createCanvas(200, 200);

  // Generate QR code and draw it on the canvas
  QRCode.toCanvas(canvas, answers.url, function (error) {
    if (error) {
      console.error(error);
      return;
    }

    console.log('QR code generated!');

    // Save the canvas as an image
    const buffer = canvas.toBuffer('image/png');
    fs.writeFileSync('qrcode.png', buffer);
    console.log('QR code saved as qrcode.png');
  });
});