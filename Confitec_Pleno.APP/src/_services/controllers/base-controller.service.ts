import { HttpClient } from "@angular/common/http";
import { environment } from "environments/environment";
import { Observable } from "rxjs";

export abstract class BaseControllerService {
    constructor(private http: HttpClient) {}

    protected get<T>(rota: string): Observable<T> {
        return this.http.get<T>(`${environment.apiUrl}${rota}`);
    }

    protected post<T, TParam>(rota: string, body: TParam | any): Observable<T> {
        return this.http.post<T>(`${environment.apiUrl}${rota}`, body);
    }

    // tslint:disable-next-line: no-any
    protected postProgress<T, TParam, Any>(rota: string, body: TParam | any, options: any): Observable<any> {
        return this.http.post<T>(`${environment.apiUrl}${rota}`, body, options);
    }

    // tslint:disable-next-line: no-any
    protected put<T, TParam>(rota: string, body: TParam | any): Observable<T> {
        return this.http.put<T>(`${environment.apiUrl}${rota}`, body);
    }

    // tslint:disable-next-line: no-any
    protected patch<T, TParam>(rota: string, body: TParam | any): Observable<T> {
        return this.http.patch<T>(`${environment.apiUrl}${rota}`, body);
    }

    protected delete<T>(rota: string): Observable<T> {
        return this.http.delete<T>(`${environment.apiUrl}${rota}`);
    }
}
