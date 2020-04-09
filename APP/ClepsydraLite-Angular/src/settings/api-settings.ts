export class APPSettings {
    private static _apiURL: string = 'https://localhost:8902/api';
  
    static get apiURL(): string {
      debugger;
      return this._apiURL;
    }
  
    static set apiURL(newName: string) {
      debugger;
      this._apiURL = newName;
    }
  }
  