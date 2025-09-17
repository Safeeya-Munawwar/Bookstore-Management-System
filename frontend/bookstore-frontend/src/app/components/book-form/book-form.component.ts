import { Component, EventEmitter, Output } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { BookService, Book } from '../../services/book.service';

@Component({
  selector: 'app-book-form',
  templateUrl: './book-form.component.html',
  styleUrls: ['./book-form.component.scss']
})
export class BookFormComponent {
  @Output() bookAdded = new EventEmitter<void>();
  submitting = false;

  bookForm = new FormGroup({
    title: new FormControl('', Validators.required),
    author: new FormControl('', Validators.required),
    isbn: new FormControl('', Validators.required),
    publishDate: new FormControl('', Validators.required),
    email: new FormControl('', [Validators.required, Validators.email])
  });

  constructor(private bookService: BookService) {}

  onSubmit(): void {
    if (this.bookForm.invalid) return;

    this.submitting = true;

    const book: Partial<Book> = {
      title: this.bookForm.value.title ?? '',
      author: this.bookForm.value.author ?? '',
      isbn: this.bookForm.value.isbn ?? '',
      publishDate: this.bookForm.value.publishDate ?? '',
      email: this.bookForm.value.email ?? ''
    };

    this.bookService.addBook(book).subscribe({
      next: () => {
        this.submitting = false;
        this.bookForm.reset();
        this.bookAdded.emit();
      },
      error: () => (this.submitting = false)
    });
  }
}
