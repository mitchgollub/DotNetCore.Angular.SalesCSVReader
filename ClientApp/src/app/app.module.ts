import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { SalesRepSummaryComponent } from './sales-rep-summary/sales-rep-summary.component';
import { AssetsUnderManagementSummaryComponent } from './assets-under-management-summary/assets-under-management-summary.component';
import { BreakReportComponent } from './break-report/break-report.component';
import { InvestorProfitComponent } from './investor-profit/investor-profit.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    SalesRepSummaryComponent,
    AssetsUnderManagementSummaryComponent,
    BreakReportComponent,
    InvestorProfitComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: SalesRepSummaryComponent },
      { path: 'assets', component: AssetsUnderManagementSummaryComponent },
      { path: 'break', component: BreakReportComponent },
      { path: 'investor', component: InvestorProfitComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
