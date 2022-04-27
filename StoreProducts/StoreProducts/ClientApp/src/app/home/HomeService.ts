import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable} from 'rxjs';
import { ProductDTO } from './ProductsDTO';


@Injectable({
  providedIn: 'root'
})
export class HomeService {
  constructor(private http: HttpClient) { }

  getProduct(): Observable<ProductDTO> {
    return this.http.get<ProductDTO>("http://(Your Local Host)/api/Products")
  }
}
