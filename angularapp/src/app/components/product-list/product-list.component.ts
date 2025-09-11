import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { Product } from '../../models/product.model';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html'
})
export class ProductListComponent implements OnInit {
  products: Product[] = [];
  selectedProduct: Product | null = null;

  constructor(private productService: ProductService) {}

  ngOnInit(): void {
    this.loadProducts();
  }

  loadProducts(): void {
    this.productService.getAll().subscribe(data => {
      this.products = data;
    });
  }

  selectProduct(product: Product) {
    this.selectedProduct = { ...product };
  }

  deleteProduct(id: number): void {
    this.productService.delete(id).subscribe(() => {
      this.loadProducts();
      this.selectedProduct = null;
    });
  }

  saveProduct(product: Product) {
    if (product.id) {
      this.productService.update(product.id, product).subscribe(() => {
        this.loadProducts();
        this.selectedProduct = null;
      });
    } else {
      this.productService.create(product).subscribe(() => {
        this.loadProducts();
        this.selectedProduct = null;
      });
    }
  }
}
