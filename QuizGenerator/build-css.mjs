import fs from 'fs';
import postcss from 'postcss';
import tailwindcss from '@tailwindcss/postcss';

const inputFile = './wwwroot/css/app.css';
const outputFile = './wwwroot/css/app.generated.css';

async function build() {
  try {
    const css = fs.readFileSync(inputFile, 'utf8');
    const result = await postcss([tailwindcss]).process(css, { 
      from: inputFile,
      to: outputFile,
      map: false
    });
    fs.writeFileSync(outputFile, result.css);
    console.log('✓ Tailwind CSS compiled successfully');
  } catch (error) {
    console.error('Error building CSS:', error);
    process.exit(1);
  }
}

build();
