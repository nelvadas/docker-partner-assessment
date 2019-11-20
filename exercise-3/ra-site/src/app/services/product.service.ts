import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';
import { ConfigService } from '../services/config.service';

import { Product } from '../model/product';

@Injectable()
export class ProductService {

  private serviceUrl: string;
  
  constructor(private http: HttpClient, private configService: ConfigService) {
    this.serviceUrl = this.configService.config.apiUrl;
  }  

  getProducts(): Observable<Product[]> {
    console.info("Calling the product service with ",this.serviceUrl)
    return this.http.get<Product[]>(this.serviceUrl+`/product`)
    .pipe(
      catchError(this.handleError('getProducts', []))
    );
  }

  getProduct(id: number): Observable<Product> {
    return this.http.get<Product>(this.serviceUrl + `/product/${id}`)
    .pipe(
      catchError(this.handleError<Product>(`getProduct id=${id}`))
    );
  }

  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
   
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead
   
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
