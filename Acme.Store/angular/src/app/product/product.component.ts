import { ListService, PagedResultDto } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProductDto, ProductService } from '@proxy/tables/products';
 @Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss'],
  providers: [ListService],
})
export class ProductComponent implements OnInit {

  TableData = { items: [], totalCount: 0 } as PagedResultDto<ProductDto>;
  selectedrow = {} as ProductDto; // declare selectedrow

  form: FormGroup;


  isModalOpen = false;
  constructor(public readonly list: ListService, private TableService: ProductService,  private confirmation: ConfirmationService // inject the ConfirmationService
,  private fb: FormBuilder) {}

  ngOnInit() {
    const bookStreamCreator = (query) => this.TableService.getList(query);

    this.list.hookToQuery(bookStreamCreator).subscribe((response) => {
      this.TableData = response;
    });
  }


  createBook() {
    this.selectedrow = {} as ProductDto; // reset the selected book
    this.buildForm();
    this.isModalOpen = true;
  }

  // Add editBook method
  editBook(id: string) {
    this.TableService.get(id).subscribe((book) => {
      this.selectedrow = book;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  buildForm() {
    this.form = this.fb.group({
      name: [this.selectedrow.name || '', Validators.required],
      price: [this.selectedrow.price || '', Validators.required],
      description: [this.selectedrow.description || '', Validators.required],
     });
  }

  // change the save method
  save() {
    if (this.form.invalid) {
      return;
    }
    const request = this.selectedrow.id
      ? this.TableService.update(this.selectedrow.id, this.form.value)
      : this.TableService.create(this.form.value);
    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    },error => {
      if (error.status === 400 && error.error.errors) {
        // Handle validation errors
        for (const controlName of Object.keys(this.form.controls)) {
          const serverErrors = error.error.errors[controlName];
          if (serverErrors && Array.isArray(serverErrors) && serverErrors.length > 0) {
            this.form.controls[controlName].setErrors({ 'serverValidation': serverErrors[0] });
          }
        }
      } else {
        // Handle other errors
      }
    });
  }
  // Add a delete method
delete(id: string) {
  this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
    if (status === Confirmation.Status.confirm) {
      this.TableService.delete(id).subscribe(() => this.list.get());
    }
  });
}
}
