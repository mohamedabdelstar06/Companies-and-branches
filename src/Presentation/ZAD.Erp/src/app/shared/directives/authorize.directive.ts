import { Directive, ElementRef, Input } from '@angular/core';


@Directive({
  selector: '[authorize]',
  standalone: true,
})
export class AuthorizeDirective {
  @Input() authorize: string | undefined;
  constructor(
    private el: ElementRef<HTMLElement>
  ) {}

  ngOnInit() {
    var authorized = true; // Mocked for C&B since SessionService doesn't exist
    if (!authorized) {
      this.el.nativeElement.setAttribute('hidden', '');
      this.el.nativeElement.style.display = 'none';
    }
  }
}
