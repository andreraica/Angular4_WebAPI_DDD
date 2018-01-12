//'use strict';
//export const cpfMask = [/\d/, /\d/, /\d/, '.', /\d/, /\d/, /\d/, '.', /\d/, /\d/, /\d/, '-', /\d/, /\d/];

import { Injectable } from '@angular/core';

@Injectable()
export class Globals {
    urlToken: string = 'http://localhost:63324';
    urlAPI: string = 'http://localhost:63324/api';
    cpfMask = [/\d/, /\d/, /\d/, '.', /\d/, /\d/, /\d/, '.', /\d/, /\d/, /\d/, '-', /\d/, /\d/];
}