import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpHeaders } from '@angular/common/http';

import { ConfigService } from '../../shared/utils/config.service';
import {BaseService} from '../../shared/services/base.service';
import { Observable } from 'rxjs';
import { HomeDetails } from '../models/home.details.interface';
import { map, catchError } from 'rxjs/operators';

@Injectable()

export class DashboardService extends BaseService {

  baseUrl: string = '';

  constructor(private http: HttpClient, private configService: ConfigService) {
     super();
     this.baseUrl = configService.getApiURI();
  }

  getHomeDetails(): Observable<HomeDetails> {
      const headers = new HttpHeaders();
      headers.append('Content-Type', 'application/json');
      const authToken = localStorage.getItem('auth_token');
      headers.append('Authorization', `Bearer ${authToken}`);

    return this.http.get(this.baseUrl + '/dashboard', { headers })
      .pipe(map((res: any) => res.json()))
      .pipe(catchError(this.handleError));
  }
}