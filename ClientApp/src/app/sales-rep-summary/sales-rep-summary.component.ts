import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-sales-summary-report',
  templateUrl: './sales-rep-summary.component.html'
})
export class SalesRepSummaryComponent {
  public summaries: SalesSummary[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<SalesSummary[]>(baseUrl + 'api/SalesSummary').subscribe(result => {
      this.summaries = result;
    }, error => console.error(error));
  }
}

interface SalesSummary {
  salesRep: string;
  y2DSold: number;
  m2DSold: number;
  q2DSold: number;
  i2DSold: number;
}
