import { computed, Directive, effect, EffectRef, HostBinding, inject, Input, OnDestroy, OnInit, signal, Signal } from '@angular/core';
import { toSignal } from '@angular/core/rxjs-interop';
import { getDayName } from '@app/core/common/common-methods';
import { CultureService } from '@app/core/services/culture/culture.service';

@Directive({
  selector: '[dayInput]',
  standalone: true
})
export class DayInputDirective {
  private cultureService = inject(CultureService)
  private culture = toSignal(this.cultureService.culture$);
  private date = signal(new Date());
  private day = computed(() => getDayName(this.date(), this.culture()));

  private dayEffect: EffectRef = effect(() => {
    this.dayValue = this.day();
  });

  @HostBinding('value')
  dayValue!: string;

  @HostBinding('disabled')
  disabled: boolean = true

  @Input('dayInput')
  set selectedDate(value: Date) {
    this.date.set(value);
  }

  ngOnDestroy() {
    if (this.dayEffect) {
      this.dayEffect.destroy();
    }
  }
}
