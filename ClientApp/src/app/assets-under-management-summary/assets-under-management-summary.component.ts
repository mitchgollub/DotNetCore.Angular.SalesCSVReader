import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-assets-under-management-summary',
  templateUrl: './assets-under-management-summary.component.html'
})
export class AssetsUnderManagementSummaryComponent {

  public summaries: AssetSummary[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<AssetSummary[]>(baseUrl + 'api/AssetsUnderManagement').subscribe(result => {
      this.summaries = result;
    }, error => console.error(error));
  }
}
  
interface AssetSummary {
  salesRep: string;
  assetAmount: number;
}
