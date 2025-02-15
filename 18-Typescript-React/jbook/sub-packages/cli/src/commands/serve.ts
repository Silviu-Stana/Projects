import path from 'path';
import { Command } from 'commander';
import { serve } from '@sealdevs/local-api';

const isProduction = process.env.NODE_ENV === 'production';

export const serveCommand = new Command()
      .command('serve [filename]')
      .description('Open a file for editing')
      .option('-p, --port <number>', 'port to run server on', '4005')
      .action(async (filename = 'notebook.js', options: { port: string }) => {
            try {
                  const dir = path.join(process.cwd(), path.dirname(filename));
                  await serve(parseInt(options.port), path.basename(filename), dir, !isProduction);
                  console.log(`Opened ${filename}. Navigate to http://localhost:${options.port}`);
            } catch (err) {
                  if (err instanceof Error) {
                        const error = err as { code?: string; message: string };
                        if (error.code === 'EADDRINUSE') console.log('Port is in use. Try running a different port.');
                  } else console.log('problem: ', err);

                  process.exit(1);
            }
      });
