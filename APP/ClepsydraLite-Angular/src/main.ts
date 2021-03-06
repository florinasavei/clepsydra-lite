import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';

export class APPSettings {
  private static _apiURL: string = 'https://localhost:8902/api';

  static get apiURL(): string {
    return this._apiURL;
  }

  static set apiURL(newName: string) {
    this._apiURL = newName;
  }
}

if (environment.production) {
  enableProdMode();
}

platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.error(err));
