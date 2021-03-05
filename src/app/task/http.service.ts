import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Sort} from './sort.model';

@Injectable({
  providedIn: 'root'
})
export class HttpService{

  serverUrl = 'http://localhost:51893/api/Task';

  constructor(private http: HttpClient){ }

  GetArray(){
    return this.http.get<number[]>(this.serverUrl + '/GetArray');
  }
  BubbleSort(){
    return this.http.get<Sort>(this.serverUrl + '/BubbleSort');
  }
  ShellSort(){
    return this.http.get<Sort>(this.serverUrl + '/ShellSort');
  }
}
