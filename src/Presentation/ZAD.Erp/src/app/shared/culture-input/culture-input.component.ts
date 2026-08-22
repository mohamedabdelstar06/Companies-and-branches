import { AsyncPipe, NgClass, NgFor, NgIf } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';
import { CultureLookupModel } from '../../core/models/common/culture-lookup.model';
import { CultureService } from '../../core/services/culture/culture.service';

@Component({
  selector: 'culture-input',
  standalone: true,
  imports: [TranslateModule, ReactiveFormsModule, NgFor, NgClass, NgIf],
  templateUrl: './culture-input.component.html',
  styleUrl: './culture-input.component.scss'
})
export class CultureInputComponent {
  @Input() title: string = 'general.name'
  @Input() name: string = 'name'
  @Input() fieldType: 'input' | 'textArea' = 'input'
  @Input() disabled: boolean = false
  @Input() formGroup: FormGroup | null = null
  @Input() submitted!: boolean
  @Input() value: CultureLookupModel[] = []

  subscriptions: any[] = []
  cultures: any[] = []

  constructor(
    private cultureService: CultureService) { }

  get f(): any {
    return this.formGroup?.controls
  }

  protected get c() {
    var item: any = {}
    this.value?.forEach(x => item[x.culture] = x.value)
    return item
  }

  ngOnInit() {
    this.subscriptions.push(
      this.cultureService
        .getCultures()
        .subscribe(result => {
          this.cultures = result
          result.forEach(x => {
            this.formGroup?.addControl(`${this.name}_${x.code}Input`, new FormControl('', [Validators.required]))
            this.setValue(this.value);
          })
        }),
    )
  }

  ngOnDestroy() {
    this.subscriptions.forEach((subscription) => {
      subscription.unsubscribe();
    });
    this.cultures.forEach(x => this.formGroup?.removeControl(`${this.name}_${x.code}Input`))
  }

  setValue(value: CultureLookupModel[]) {
    if (this.formGroup) {
      var obj: any = {}
      value?.forEach(x => obj[`${this.name}_${x.culture}Input`] = x.value)
      this.formGroup.patchValue(obj);
    }
  }

  getValue(): CultureLookupModel[] {
    return this.cultures.map(x => ({ culture: x.code, value: this.f[`${this.name}_${x.code}Input`].value }))
  }
}
