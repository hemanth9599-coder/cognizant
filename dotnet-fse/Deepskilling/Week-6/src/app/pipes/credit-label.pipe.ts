import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'creditLabel' })
export class CreditLabelPipe implements PipeTransform {
  transform(credits: number | null | undefined): string {
    if (!credits || credits < 1) return 'No Credits';
    return `${credits} ${credits === 1 ? 'Credit' : 'Credits'}`;
  }
}
