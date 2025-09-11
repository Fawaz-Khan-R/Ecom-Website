import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Product } from '../../models/product.model';

@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html'
})
export class ProductFormComponent {
  @Input() product: Product = { id: 0, name: '', price: 0, quantity: 0, description: '', category: '' };
  @Output() save = new EventEmitter<Product>();

  onSubmit() {
    this.save.emit(this.product);
  }
}
