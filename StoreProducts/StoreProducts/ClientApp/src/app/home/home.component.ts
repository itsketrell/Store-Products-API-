import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { HomeService } from './HomeService';
import { ProductDTO } from './ProductsDTO';

@Component({
  selector: 'app-home',
  styleUrls: ['/style.css'],
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  constructor(private HomeService: HomeService) { }


  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  product: ProductDTO[] = []
  dataSource = new MatTableDataSource<ProductDTO>();
  displayedColumns = ["ProductId", "ProductName", "Category", "Price"]
  
  getProducts() {
    this.HomeService.getProduct().subscribe(
      (result: any) => {
        this.dataSource = new MatTableDataSource(result);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
        console.log(result)
      });
  }
  ngOnInit() {
    this.getProducts()
    
  }

}

