import express from 'express';
import { createProxyMiddleware } from 'http-proxy-middleware';
import path from 'path';
import { createCellsRouter } from './routes/cells';

export const serve = (port: number, filename: string, dir: string, useProxy: boolean) => {
      const app = express();

      app.use(createCellsRouter(filename, dir));

      //Dev mode, the actual app behind the scene
      if (useProxy) {
            app.use(
                  createProxyMiddleware({
                        target: 'http://127.0.0.1:3000',
                        ws: true,
                        changeOrigin: true,
                  })
            );
      } //User developing on their local machine
      else {
            const packagePath = require.resolve('@sealdevs/local-client/build/index.html');
            app.use(express.static(path.dirname(packagePath)));
      }

      return new Promise<void>((resolve, reject) => {
            app.listen(port, () => {
                  console.log('listen on port ', port);
                  resolve();
            }).on('error', reject);
      });
};
