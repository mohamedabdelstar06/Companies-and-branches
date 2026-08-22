import { Component, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { CultureLookupDto } from '@app/core/service-proxies/service-proxies';
import { CultureInputComponent } from '@app/shared/culture-input/culture-input.component';
import { TranslateModule } from '@ngx-translate/core';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';

@Component({
  selector: 'app-lookup-popup',
  standalone: true,
  imports: [CultureInputComponent, TranslateModule],
  templateUrl: './lookup-popup.component.html',
  styleUrl: './lookup-popup.component.scss'
})
export class LookupPopupComponent {
  @ViewChild('nameInput') nameInput!: CultureInputComponent;

  form: FormGroup = this.formBuilder.group({});
  data = this.config.data || {};
  submitted = false;

  constructor(
    public ref: DynamicDialogRef,
    public config: DynamicDialogConfig,
    private formBuilder: FormBuilder
  ) { }

  ngAfterViewInit() {
    this.nameInput
      .setValue(this.data.cultures?.map((x: any) => ({ culture: x.culture, value: x.value })));

    if (this.data.view === true)
      this.form.disable();
  }

  close() {
    this.ref.close();
  }

  save() {
    this.submitted = true;
    var lookup: any = this.data;
    lookup.cultures = this.nameInput
      .getValue().map((x) => new CultureLookupDto({ culture: x.culture, value: x.value }));
    lookup.isActive = true;
    this.ref.close(lookup);
  }
}
